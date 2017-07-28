namespace Hubo.Shifts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Hubo.EntityFramework;
    using Hubo.Shifts.Dto;
    using PdfSharp;
    using PdfSharp.Drawing;
    using PdfSharp.Pdf;
    using PdfSharp.Pdf.IO;
    using System.Diagnostics;
    using TheArtOfDev.HtmlRenderer.PdfSharp;
    

    public class ShiftAppService
    {
        private WorkShiftRepository _shiftRepository;
        private DriverRepository _driverRepository;
        private BreakRepository _breakRepository;
        private DrivingShiftRepository _drivingShiftRepository;

        public ShiftAppService()
        {
            _shiftRepository = new EntityFramework.WorkShiftRepository();
            _driverRepository = new EntityFramework.DriverRepository();
            _breakRepository = new EntityFramework.BreakRepository();
            _drivingShiftRepository = new EntityFramework.DrivingShiftRepository();
        }

        public Tuple<int, string> StartShift(WorkShift shift)
        {
            return _shiftRepository.StartShift(shift);
        }

        public Tuple<int, string> StopShift(WorkShift shift)
        {
            Tuple<int, string> result = _shiftRepository.StopShift(shift);
            if (result.Item1 == 1)
            {
                // Create PDF and send out to supervisor

                //Get Drives from this shift
                //List<long> workShiftIds = new List<long>();
                //workShiftIds.Add(shift.Id);
                //List<DrivingShift> listOfDrives = _driverRepository.GetDrivingShifts(workShiftIds);

                ////Get Breaks from this shift

                //Tuple<List<Break>, string, int> listOfBreaksResult = _breakRepository.GetBreaks(shift.Id);
                //List<Break> listOfBreaks = listOfBreaksResult.Item1;

            }

            return result;
        }

        public Tuple<int, string> StartDay(int driverId)
        {
            return _shiftRepository.StartDay(driverId);
        }

        public List<WorkShiftDto> GetWorkShifts(int driverId)
        {
            Tuple<List<WorkShift>, string, int> result = _shiftRepository.GetWorkShifts(driverId);
            List<WorkShiftDto> listWorkShiftDto = new List<WorkShiftDto>();
            foreach (WorkShift workShift in result.Item1)
            {
                listWorkShiftDto.Add(Mapper.Map<WorkShift, WorkShiftDto>(workShift));
            }
            return listWorkShiftDto;
        }

        //public Tuple<DayShiftResponseModel, string, int> GetDayShifts(int driverId)
        //{
        //    throw new NotImplementedException();
        //}

        public Tuple<int, string> GeneratePdf(int workShiftId)
        {
            //Get the number of workshift of the day
            int noOfWorkShifts = _shiftRepository.GetAmountOfShifts(workShiftId);

            //Get the current workshift
            WorkShift currentWorkshift = _shiftRepository.GetWorkShift(workShiftId);
            if (currentWorkshift == null)
            {
                return Tuple.Create(-1, "Unable to find WorkShift");
            }

            //Get all drives
            List<DrivingShift> listOfDrivingShifts = _drivingShiftRepository.GetDrivingShiftsWorkId(workShiftId);

            //Get all breaks
            List<Break> listOfBreaks = _breakRepository.GetBreaksList(workShiftId);

            return Tuple.Create(1, "Fsadf");
        }

        public int TestGen()
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Test Generation";

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

            // Draw the text
            gfx.DrawString("Hello, World!", font, XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height),
            XStringFormats.Center);

            // Save the document...
            const string filename = "HelloWorld.pdf";
            string test  = AppDomain.CurrentDomain.BaseDirectory;
            string html = System.IO.File.ReadAllText(test + "test.html");
            PdfDocument htmltest = PdfGenerator.GeneratePdf(html, PageSize.Letter);
            htmltest.Save(test + filename);
            //// ...and start a viewer.
            //Process.Start(filename);
            return 1;
        }
    }
}
