using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo
{
    public class ShiftBreakNote : FullAuditedEntity
    {
        public bool StandAloneNote { get; set; }
        public Note Note { get; set; }
        public int BreakShiftId { get; set; }

    }
}
