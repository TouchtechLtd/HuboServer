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
        public long Id { get; set; }
        public long DriveShiftId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool isActive { get; set; }
        public long VehicleId { get; set; }
    }
}
