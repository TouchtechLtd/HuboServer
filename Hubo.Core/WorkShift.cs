namespace Hubo
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Abp.Domain.Entities.Auditing;

    public class WorkShift : FullAuditedEntity
    {
        public long DriverId { get; set; }
        public long CompanyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal StartLocationLat { get; set; }
        public decimal StartLocationLong { get; set; }
        public decimal EndLocationLat { get; set; }
        public decimal EndLocationLong { get; set; }
        public bool State { get; set; }
    }
}