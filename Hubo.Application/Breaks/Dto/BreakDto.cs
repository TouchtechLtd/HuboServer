using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.Breaks.Dto
{
    [AutoMap(typeof(Break))]
    public class BreakDto
    {
        public int Id { get; set; }
        public long ShiftId { get; set; }
        public DateTime? StartBreakDateTime { get; set; }
        public DateTime? StopBreakDateTime { get; set; }
        public string StartBreakLocation { get; set; }
        public string StopBreakLocation { get; set; }
        public bool isActive { get; set; }
    }
}
