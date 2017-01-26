using Hubo.ApiRequestClasses;
using Hubo.EntityFramework;
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

        public Tuple<int,string> StartShift(ShiftStartRequest shift)
        {
            return _shiftRepository.StartShift(shift);
        }

        public Tuple<int,string> StopShift(ShiftStopRequest shift)
        {
            return _shiftRepository.StopShift(shift);
        }

        public Tuple<int,string> StartBreak(BreakStartRequest shiftBreak)
        {
            return _shiftRepository.StartBreak(shiftBreak);
        }

        public Tuple<int, string> EndBreak(BreakEndRequest shiftBreak)
        {
            return _shiftRepository.EndBreak(shiftBreak);
        }
    }
}
