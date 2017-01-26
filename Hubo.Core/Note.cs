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
        public string NoteText { get; set; }
        public DateTime Date { get; set; }
        public int Hubo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
