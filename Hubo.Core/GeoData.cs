namespace Hubo
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Abp.Domain.Entities.Auditing;

    public class GeoData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int DrivingShiftId { get; set; }

        public DateTime TimeStamp { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

    }
}
