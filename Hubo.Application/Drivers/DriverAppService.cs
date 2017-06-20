namespace Hubo.Drivers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using AutoMapper;
    using CsvHelper;
    using Hubo.Drivers.Dto;
    using Hubo.EntityFramework;
    using Hubo.Users;
    using SendGrid;
    using NPOI.SS.UserModel;
    using NPOI.HSSF.UserModel;
    using NPOI.HPSF;

    public class DriverAppService
    {

        private DriverRepository driverRepository;

        public DriverAppService()
        {
            this.driverRepository = new EntityFramework.DriverRepository();
        }

        public int RegisterDriver(Driver driver)
        {
            int i = this.driverRepository.RegisterDriver(driver);

            return i;
        }

        public User GetUserDetails(string usernameOrEmailAddress)
        {
            return this.driverRepository.GetUserDetails(usernameOrEmailAddress);
        }

        public long GetDriverId(long id)
        {
            return this.driverRepository.GetDriverId(id);
        }

        public Tuple<DriverOutput,List<LicenceOutputDto>, int, string> GetDriverDetails(int userId)
        {
            List<Licence> listOfLicences = new List<Licence>();
            List<LicenceOutputDto> listOfLicenceDtos = new List<LicenceOutputDto>();

            Tuple<Driver, int, string> driverDetailsresult = this.driverRepository.GetDriverDetails(userId);

            listOfLicences = this.driverRepository.GetLicences(driverDetailsresult.Item1.Id);
            foreach (Licence licence in listOfLicences)
            {
                listOfLicenceDtos.Add(Mapper.Map<Licence, LicenceOutputDto>(licence));
            }
            return Tuple.Create(Mapper.Map<Driver, DriverOutput>(driverDetailsresult.Item1), listOfLicenceDtos, driverDetailsresult.Item2, driverDetailsresult.Item3);

        }

        public Tuple<int, string> ExportData(int driverId)
        {

            List<WorkShift> listOfWorkShifts = this.driverRepository.GetShiftFromLastLongBreak(driverId);
            if (listOfWorkShifts.Count != 0)
            {
                List<long> listOfWorksShiftIds = new List<long>();
                foreach (WorkShift workShift in listOfWorkShifts)
                {
                    listOfWorksShiftIds.Add(workShift.Id);
                }

                List<DrivingShift> listOfDrivingShifts = this.driverRepository.GetDrivingShifts(listOfWorksShiftIds);
                List<Break> listOfBreaks = this.driverRepository.GetBreaks(listOfWorksShiftIds);
                List<Note> listOfNotes = this.driverRepository.GetNotes(listOfWorksShiftIds);
                //TextWriter textWriter = File.CreateText("C:\\Dev\\HuboServer\\test.csv");
                //var csv = new CsvWriter(textWriter);
                //csv.WriteRecords(listOfBreaks);
                //csv.WriteRecords(listOfNotes);
                //csv.WriteRecords(listOfDrivingShifts);
                //textWriter.Close();

                HSSFWorkbook hssfWorkBook = new HSSFWorkbook();

                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "Hubo";
                hssfWorkBook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Subject = "Shifts";
                hssfWorkBook.SummaryInformation = si;

                int shiftCounter = 1;

                foreach (WorkShift workShift in listOfWorkShifts)
                {
                    int rowCounter = 0;

                    ISheet sheet1 = hssfWorkBook.CreateSheet("Shift " + shiftCounter.ToString());

                    sheet1.CreateRow(rowCounter).CreateCell(0).SetCellValue("***SHIFT***");
                    rowCounter++;

                    sheet1.SetColumnWidth(0, 25 * 256);
                    sheet1.SetColumnWidth(1, 25 * 256);
                    sheet1.SetColumnWidth(2, 25 * 256);
                    sheet1.SetColumnWidth(3, 25 * 256);
                    sheet1.SetColumnWidth(4, 25 * 256);
                    sheet1.SetColumnWidth(5, 25 * 256);

                    IRow row1 = sheet1.CreateRow(rowCounter);
                    rowCounter++;

                    row1.CreateCell(0).SetCellValue("Start Time:");
                    row1.CreateCell(1).SetCellValue("Start Location:");
                    row1.CreateCell(2).SetCellValue("End Time:");
                    row1.CreateCell(3).SetCellValue("End Location:");
                    row1.CreateCell(4).SetCellValue("Total Time:");

                    IRow row2 = sheet1.CreateRow(rowCounter);
                    rowCounter++;

                    row2.CreateCell(0).SetCellValue(workShift.StartDate.ToString());
                    row2.CreateCell(1).SetCellValue(workShift.StartLocation);
                    row2.CreateCell(2).SetCellValue(workShift.EndDate.ToString());
                    row2.CreateCell(3).SetCellValue(workShift.EndLocation);
                    row2.CreateCell(4).SetCellValue((workShift.EndDate - workShift.StartDate).ToString());

                    // Just for some space
                    rowCounter = rowCounter + 3;

                    sheet1.CreateRow(rowCounter).CreateCell(0).SetCellValue("***DRIVING TIMES***");
                    rowCounter++;

                    IRow drivingShiftTextRow = sheet1.CreateRow(rowCounter);
                    rowCounter++;

                    drivingShiftTextRow.CreateCell(0).SetCellValue("Start Time: ");
                    drivingShiftTextRow.CreateCell(1).SetCellValue("Start Odometer: ");
                    drivingShiftTextRow.CreateCell(2).SetCellValue("End Time: ");
                    drivingShiftTextRow.CreateCell(3).SetCellValue("End Odometer: ");
                    drivingShiftTextRow.CreateCell(4).SetCellValue("Total Time: ");
                    drivingShiftTextRow.CreateCell(5).SetCellValue("Total Odometer: ");

                    foreach (DrivingShift drivingShift in listOfDrivingShifts)
                    {
                        if (drivingShift.ShiftId == workShift.Id)
                        {
                            IRow drivingShiftValueRow = sheet1.CreateRow(rowCounter);
                            rowCounter++;

                            drivingShiftValueRow.CreateCell(0).SetCellValue(drivingShift.StartDrivingDateTime.ToString());
                            drivingShiftValueRow.CreateCell(1).SetCellValue(drivingShift.StartHubo.ToString());
                            drivingShiftValueRow.CreateCell(2).SetCellValue(drivingShift.StopDrivingDateTime.ToString());
                            drivingShiftValueRow.CreateCell(3).SetCellValue(drivingShift.StopHubo.ToString());
                            drivingShiftValueRow.CreateCell(4).SetCellValue((drivingShift.StopDrivingDateTime - drivingShift.StartDrivingDateTime).ToString());
                            drivingShiftValueRow.CreateCell(5).SetCellValue(drivingShift.StopHubo - drivingShift.StartHubo);
                        }
                    }

                    rowCounter = rowCounter + 3;

                    sheet1.CreateRow(rowCounter).CreateCell(0).SetCellValue("***BREAKS***");
                    rowCounter++;

                    IRow breakTextRow = sheet1.CreateRow(rowCounter);
                    rowCounter++;

                    breakTextRow.CreateCell(0).SetCellValue("Start Break Time: ");
                    breakTextRow.CreateCell(1).SetCellValue("Start Location: ");
                    breakTextRow.CreateCell(2).SetCellValue("End Break Time: ");
                    breakTextRow.CreateCell(3).SetCellValue("End Location: ");
                    breakTextRow.CreateCell(4).SetCellValue("Total Break Time: ");

                    foreach (Break shiftBreak in listOfBreaks)
                    {
                        if (shiftBreak.ShiftId == workShift.Id)
                        {
                            IRow breakValueRow = sheet1.CreateRow(rowCounter);
                            rowCounter++;

                            breakValueRow.CreateCell(0).SetCellValue(shiftBreak.StartBreakDateTime.ToString());
                            breakValueRow.CreateCell(1).SetCellValue(shiftBreak.StartBreakLocation);
                            breakValueRow.CreateCell(2).SetCellValue(shiftBreak.StopBreakDateTime.ToString());
                            breakValueRow.CreateCell(3).SetCellValue(shiftBreak.StopBreakLocation);
                            breakValueRow.CreateCell(4).SetCellValue((shiftBreak.StopBreakDateTime - shiftBreak.StartBreakDateTime).ToString());
                        }
                    }

                    rowCounter = rowCounter + 3;

                    sheet1.CreateRow(rowCounter).CreateCell(0).SetCellValue("***NOTES***");
                    rowCounter++;

                    IRow noteRowText = sheet1.CreateRow(rowCounter);
                    rowCounter++;

                    noteRowText.CreateCell(0).SetCellValue("Note: ");
                    noteRowText.CreateCell(1).SetCellValue("TimeStamp: ");

                    foreach (Note note in listOfNotes)
                    {
                        if (note.ShiftId == workShift.Id)
                        {
                            IRow noteRowValues = sheet1.CreateRow(rowCounter);
                            rowCounter++;

                            noteRowValues.CreateCell(0).SetCellValue(note.NoteText);
                            noteRowValues.CreateCell(1).SetCellValue(note.TimeStamp);
                        }
                    }

                    shiftCounter++;
                }

                // Excel requires at minimum 4 sheets?? So check if 4 have been made, if not lets do it
                while (shiftCounter < 5)
                {
                    ISheet sheet1 = hssfWorkBook.CreateSheet("Shift " + shiftCounter.ToString());
                    shiftCounter++;
                }

                FileStream file = new FileStream(@"C:\\Dev\\HuboServer\\test.xls", FileMode.Create);
                hssfWorkBook.Write(file);
                file.Close();

                this.SendEmail().Wait();
            }
            else
            {
                return Tuple.Create(-1, "No Work Shifts found for prior week");
            }

            return Tuple.Create(-1, "No Work Shifts found for prior week");
        }

        private async Task SendEmail()
        {
            SendGridMessage myMessage = new SendGridMessage();
            myMessage.AddTo("ben@triotech.co.nz");
            myMessage.From = new MailAddress("support@triotech.co.nz", "Trio Support");
            myMessage.Subject = "Work Shifts Requested";
            myMessage.Text = "These are the shifts that were requested";
            myMessage.AddAttachment("C:\\Dev\\HuboServer\\test.xls");

            var transportWeb = new Web("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");
            try
            {
                await transportWeb.DeliverAsync(myMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
