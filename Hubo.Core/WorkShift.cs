namespace Hubo
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Abp.Domain.Entities.Auditing;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WorkShift : FullAuditedEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public long CompanyId { get; set; }
        public long DriverId { get; set; }
        public long DayShiftId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal StartLocationLat { get; set; }
        public decimal StartLocationLong { get; set; }
        public decimal EndLocationLat { get; set; }
        public decimal EndLocationLong { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public bool isActive { get; set; }
        public long TimeSinceLastShiftMins { get; set; }
        public string StartNote { get; set; }
        public string EndNote { get; set; }
    }
}