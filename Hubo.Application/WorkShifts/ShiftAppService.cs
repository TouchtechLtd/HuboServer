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

        public ShiftAppService()
        {
            _shiftRepository = new EntityFramework.WorkShiftRepository();
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


    }
}
