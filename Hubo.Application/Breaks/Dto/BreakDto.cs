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
        public long ShiftId { get; set; }
        public long GeoDataId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool State { get; set; }
    }
}
