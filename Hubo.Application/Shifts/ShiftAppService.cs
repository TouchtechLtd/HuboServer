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

        //public int StartShift(Shift shift)
        //{
        //    return _shiftRepository.StartShift(shift);
        //}

        //public int StopShift(Shift shift)
        //{
        //    return _shiftRepository.StopShift(shift);
        //}

        //public int StartBreak(Break shiftBreak)
        //{
        //    return _shiftRepository.StartBreak(shiftBreak);
        //}

        //public int EndBreak(Break shiftBreak)
        //{
        //    return _shiftRepository.EndBreak(shiftBreak);
        //}
    }
}
