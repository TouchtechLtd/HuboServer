using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.Shifts.Dto
{
    [AutoMap(typeof(DrivingShift))]
    public class DrivingShiftDto
    {
        public long ShiftId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool State { get; set; }
        public long VehicleId { get; set; }
    }
}
