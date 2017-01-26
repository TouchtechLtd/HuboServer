namespace Hubo
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Abp.Domain.Entities.Auditing;

    public class Shift : FullAuditedEntity
    {
        public long DriverId { get; set; }
        public long VehicleId { get; set; }
        public long ShiftBreakNoteStartId { get; set; }
        public long ShiftBreakNoteStopId { get; set; }
    }
}