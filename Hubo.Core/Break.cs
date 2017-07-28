using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hubo
{
    public class Break
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public DateTime? StartBreakDateTime { get; set; }
        public DateTime? StopBreakDateTime { get; set; }
        public string StartBreakLocation { get; set; }
        public string StopBreakLocation { get; set; }
        public bool isActive { get; set; }
        public string StartNote { get; set; }
        public string EndNote { get; set; }
    }
}
