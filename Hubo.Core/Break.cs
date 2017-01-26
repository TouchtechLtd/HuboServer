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
        public long ShiftId { get; set; }
        public int ShiftBreakNoteStartId { get; set; }
        public int ShiftBreakNoteStopId { get; set; }
    }
}
