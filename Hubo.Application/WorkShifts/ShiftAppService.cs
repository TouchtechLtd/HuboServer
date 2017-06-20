using AutoMapper;
using Hubo.EntityFramework;
using Hubo.Shifts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hubo.Shifts
{
    public class ShiftAppService
    {
        private WorkShiftRepository _shiftRepository;
        private DriverRepository _driverRepository;
        private BreakRepository _breakRepository;

        public ShiftAppService()
        {
            _shiftRepository = new EntityFramework.WorkShiftRepository();
        }

        public Tuple<int, string> StartShift(WorkShift shift)
        {
            return _shiftRepository.StartShift(shift);
        }

        public Tuple<int,string> StopShift(WorkShift shift)
        {
            Tuple<int, string> result = _shiftRepository.StopShift(shift);
            if (result.Item1 == 1)
            {
                // Create PDF and send out to supervisor

                //Get Drives from this shift
                List<long> workShiftIds = new List<long>();
                workShiftIds.Add(shift.Id);
                List<DrivingShift> listOfDrives = _driverRepository.GetDrivingShifts(workShiftIds);

                //Get Breaks from this shift

                Tuple<List<Break>, string, int> listOfBreaksResult = _breakRepository.GetBreaks(shift.Id);
                List<Break> listOfBreaks = listOfBreaksResult.Item1;

            }

            return result;
        }

        public Tuple<int, string> StartDay(int driverId)
        {
            return _shiftRepository.StartDay(driverId);
        }

        public Tuple<List<WorkShiftDto>, string, int> GetWorkShifts(int driverId)
        {
            Tuple<List<WorkShift>, string, int> result = _shiftRepository.GetWorkShifts(driverId);
            List<WorkShiftDto> listWorkShiftDto = new List<WorkShiftDto>();
            foreach (WorkShift workShift in result.Item1)
            {
                listWorkShiftDto.Add(Mapper.Map<WorkShift, WorkShiftDto>(workShift));
            }
            return Tuple.Create(listWorkShiftDto, result.Item2, result.Item3);
        }
    }
}
