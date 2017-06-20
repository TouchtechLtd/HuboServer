using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.Api.Models
{
    public class StartShiftRequestModel
    {
        public long DriverId { get; set; }
        public WorkShift WorkShift { get; set; }
    }
}
