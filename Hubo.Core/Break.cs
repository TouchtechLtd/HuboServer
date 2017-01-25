using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo
{
    public class Break : FullAuditedEntity
    {
        public int ShiftId { get; set; }
        public DateTime? StartBreakTime { get; set; }
        public DateTime? EndBreakTime { get; set; }
        public int StartNoteKey { get; set; }
        public int EndNoteKey { get; set; }
        public ShiftBreakNote ShiftBreakNote { get; set; }
    }
}
