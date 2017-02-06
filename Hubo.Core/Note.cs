using System;
using System.Data.Entity;
using System.Linq;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using Hubo;
using System.ComponentModel.DataAnnotations;

namespace Hubo
{
    public class Note : FullAuditedEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }
        public long ShiftId { get; set; }
        public long BreakId { get; set; }
        public long DrivingShiftId { get; set; }
        public string NoteText { get; set; }
        public int GeoDataLink { get; set; }
        public DateTime TimeStamp { get; set; }
        public long Hubo { get; set; }
    }
}
