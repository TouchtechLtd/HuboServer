namespace Hubo
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Abp.Domain.Entities.Auditing;

    public class Shift : FullAuditedEntity
    {
        public int CompanyId { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public decimal Start_location_lat { get; set; }
        public decimal Start_location_long { get; set; }
        public decimal End_location_lat { get; set; }
        public decimal End_location_long { get; set; }
    }
}