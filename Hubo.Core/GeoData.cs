namespace Hubo
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Abp.Domain.Entities.Auditing;

    public class GeoData : FullAuditedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        public long DrivingShiftId { get; set; }

        public DateTime TimeStamp { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

    }
}
