using AutoMapper;
using Hubo.ApiRequestClasses;
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
        private ShiftRepository _shiftRepository;

        public ShiftAppService()
        {
            _shiftRepository = new EntityFramework.ShiftRepository();
        }

        public Tuple<int,string> StartShift(WorkShift shift)
        {
            return _shiftRepository.StartShift(shift);
        }

        public Tuple<int,string> StopShift(WorkShift shift)
        {
            return _shiftRepository.StopShift(shift);
        }

        public Tuple<List<WorkShiftDto>, string, int> GetWorkShifts(int driverId)
        {
            Tuple<List<WorkShift>, string, int> result = _shiftRepository.GetWorkShifts(driverId);
            List<WorkShiftDto> listWorkShiftDto = new List<WorkShiftDto>();
            foreach(WorkShift workShift in result.Item1)
            {
                listWorkShiftDto.Add(Mapper.Map<WorkShift, WorkShiftDto>(workShift));
            }
            return Tuple.Create(listWorkShiftDto, result.Item2, result.Item3);
        }

        public Tuple<List<DrivingShiftDto>, string, int> GetDrivingShifts(int shiftId)
        {
            Tuple<List<DrivingShift>, string, int> result = _shiftRepository.GetDrivingShifts(shiftId);
            List<DrivingShiftDto> listWorkShiftDto = new List<DrivingShiftDto>();
            foreach (DrivingShift workShift in result.Item1)
            {
                listWorkShiftDto.Add(Mapper.Map<DrivingShift, DrivingShiftDto>(workShift));
            }
            return Tuple.Create(listWorkShiftDto, result.Item2, result.Item3);
        }
    }
}
