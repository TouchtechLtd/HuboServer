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
        public int Id { get; set; }
        public long ShiftId { get; set; }
        public DateTime? StartDrivingDateTime { get; set; }
        public DateTime? StopDrivingDateTime { get; set; }
        public long StartHubo { get; set; }
        public long StopHubo { get; set; }
        public bool isActive { get; set; }
        public long VehicleId { get; set; }
    }
}
