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
    public class DrivingShift : FullAuditedEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public long ShiftId { get; set; }
        public DateTime? StartDrivingDateTime { get; set; }
        public DateTime? StopDrivingDateTime { get; set; }
        public long StartHubo { get; set; }
        public long StopHubo { get; set; }
        public bool isActive { get; set; }
        public long VehicleId { get; set; }
        public string StartNote { get; set; }
        public string EndNote { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
    }
}
