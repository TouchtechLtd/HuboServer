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
    public class DrivingShift
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public int VehicleId { get; set; }
        public DateTime? StartDrivingDateTime { get; set; }
        public DateTime? StopDrivingDateTime { get; set; }
        public int StartHubo { get; set; }
        public int StopHubo { get; set; }
        public bool isActive { get; set; }        
        public string StartNote { get; set; }
        public string EndNote { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
    }
}
