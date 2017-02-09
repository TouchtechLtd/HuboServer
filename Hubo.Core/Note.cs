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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public long ShiftId { get; set; }
        public string NoteText { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
