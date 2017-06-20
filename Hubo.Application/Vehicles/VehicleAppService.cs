using Hubo.Vehicles.Dto;
using Hubo.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.ProjectOxford.Vision.Contract;
using Microsoft.ProjectOxford.Vision;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Hubo.Vehicles
{
    public class VehicleAppService
    {
        private VehicleRepository _vehicleRepository;

        public VehicleAppService()
        {
            _vehicleRepository = new EntityFramework.VehicleRepository();
        }

        public Tuple<int,string> RegisterVehicle(Vehicle vehicle)
        {
            vehicle.RegistrationNo = vehicle.RegistrationNo.ToUpper();
            return _vehicleRepository.RegisterVehicle(vehicle);
        }

        public Tuple<List<VehicleOutput>, string, int> GetVehiclesByDriver(int driverId)
        {
            Tuple<List<Vehicle>, string, int> result = _vehicleRepository.GetVehiclesByDriver(driverId);
            List<VehicleOutput> listOfDtoVehicles = new List<VehicleOutput>();
            foreach (Vehicle vehicle in result.Item1)
            {
                listOfDtoVehicles.Add(Mapper.Map<Vehicle, VehicleOutput>(vehicle));
            }

            return Tuple.Create(listOfDtoVehicles, result.Item2, result.Item3);
        }

        // TODO: Give it a unique name, save the image, then save the string to the location, then do OCR recognition, then return back the new vehicle id.
        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }

        public async Task<List<string>> MicrosoftOCRCallAsync(Image regoPictureString)
        {
            //byte[] toBytes = Encoding.ASCII.GetBytes(regoPictureString);
            var stream = new System.IO.MemoryStream();
            regoPictureString.Save(stream, ImageFormat.Jpeg);

            stream.Position = 0;

            var ocrClient = new VisionServiceClient("a2642181157b4664a1f6defc36dfabeb");

            OcrResults results;

            try
            {
                results = await ocrClient.RecognizeTextAsync(stream);
            }
            catch (Exception ex)
            {
                return null;
            }

            //OcrResults results = JsonConvert.DeserializeObject<OcrResults>(response.Content.ReadAsStringAsync().Result);

            List<string> regoList = new List<string>();
            Regex r = new Regex("^[A-Za-z0-9Ø]*$");
            //foreach (Microsoft.ProjectOxford.Vision.Contract.Region region in response.Regions)
            //{
            //    foreach (Line line in region.Lines)
            //    {
            //        string fullLine = string.Empty;
            //        foreach (Word word in line.Words)
            //        {
            //            word.Text = word.Text.Replace(".", string.Empty).Replace(",", string.Empty);

            //            if (r.IsMatch(word.Text.ToString()))
            //            {
            //                fullLine = fullLine + word.Text.ToString();
            //            }
            //        }

            //        if (fullLine != string.Empty && fullLine.Trim().Length < 7)
            //        {
            //            List<string> listOfPossibilities = CheckPossiblities(fullLine);

            //            foreach (string possibility in listOfPossibilities)
            //            {
            //                regoList.Add(possibility);
            //            }
            //        }
            //    }
            //}

            return regoList;

        }

        internal List<string> CheckPossiblities(string fullLine)
        {
            List<string> fullSetPossibilities = new List<string>();
            fullLine = Regex.Replace(fullLine, "Ø", "0");
            fullLine = Regex.Replace(fullLine, "i", "1");
            fullLine = Regex.Replace(fullLine, "l", "1");
            fullSetPossibilities.Add(fullLine);
            if (fullLine.Contains("I"))
            {
                List<string> possibilities = Combinations(fullLine, 'I', "1").ToList();
                foreach (string possibility in possibilities)
                {
                    fullSetPossibilities.Add(possibility);
                }
            }

            return fullSetPossibilities.Distinct().ToList();
        }

        public IEnumerable<string> Combinations(string input, char initialChar, string replacementChar)
        {
            var head = input[0] == initialChar // Do I have a `0`?
                ? new[] { initialChar.ToString(), replacementChar } // If so output both `"0"` & `"o"`
                : new[] { input[0].ToString() }; // Otherwise output the current character

            var tails = input.Length > 1 // Is there any more string?
                ? Combinations(input.Substring(1), initialChar, replacementChar) // Yes, recursively compute
                : new[] { string.Empty }; // Otherwise, output empty string

            // Now, join it up and return
            return
                from h in head
                from t in tails
                select h + t;
        }
    }
}
