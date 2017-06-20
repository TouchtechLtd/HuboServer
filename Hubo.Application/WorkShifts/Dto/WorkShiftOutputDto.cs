using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.Shifts.Dto
{
    [AutoMap(typeof(WorkShift))]
    public class WorkShiftOutputDto
    {
        public long Id { get; set; }
        public long DayShiftId { get; set; }
    }
}
