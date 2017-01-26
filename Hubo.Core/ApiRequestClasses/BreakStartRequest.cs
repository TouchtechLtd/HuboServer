using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.ApiRequestClasses
{
    public class BreakStartRequest
    {
        public long ShiftId { get; set; }
        public Note Note { get; set; }
    }
}
