using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.Shifts.Dto
{
    [AutoMap(typeof(WorkShift))]
    public class WorkShiftDto
    {
        public long Id { get; set; }
        public long DriverId { get; set; }
        public long CompanyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal StartLocationLat { get; set; }
        public decimal StartLocationLong { get; set; }
        public decimal EndLocationLat { get; set; }
        public decimal EndLocationLong { get; set; }
        public bool isActive { get; set; }
    }
}
