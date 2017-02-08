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
        public DateTime TimeStamp { get; set; }
        public bool State { get; set; }
    }
}
