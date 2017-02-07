using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hubo.Shifts.Dto;
using Hubo.EntityFramework;
using AutoMapper;

namespace Hubo.DrivingShifts
{
    public class DrivingShiftAppService
    {
        private DrivingShiftRepository _drivingShiftRepository;

        public DrivingShiftAppService()
        {
            _drivingShiftRepository = new EntityFramework.DrivingShiftRepository();
        }

        public Tuple<List<DrivingShiftDto>, string, int> GetDrivingShifts(int shiftId)
        {
            Tuple<List<DrivingShift>, string, int> result = _drivingShiftRepository.GetDrivingShifts(shiftId);
            List<DrivingShiftDto> listWorkShiftDto = new List<DrivingShiftDto>();
            foreach (DrivingShift workShift in result.Item1)
            {
                listWorkShiftDto.Add(Mapper.Map<DrivingShift, DrivingShiftDto>(workShift));
            }
            return Tuple.Create(listWorkShiftDto, result.Item2, result.Item3);
        }

        public Tuple<int, string> StartDriving(DrivingShift shift)
        {
            return _drivingShiftRepository.StartDriving(shift);
        }

        public Tuple<int, string> StopDriving(int drivingShiftId)
        {
            return _drivingShiftRepository.StopDriving(drivingShiftId);
        }
    }
}
