using System;
using System.Data.Entity;
using System.Linq;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using Hubo;
using System.ComponentModel.DataAnnotations;

namespace Hubo
{
    public class Note
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public string NoteText { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
