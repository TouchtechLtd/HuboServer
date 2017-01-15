namespace Hubo
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using Abp.Domain.Entities.Auditing;
    using System.ComponentModel.DataAnnotations;

    public class Vehicle
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RegistrationNo { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int StartingOdometer { get; set; }
        public int CurrentOdometer { get; set; }
        public int CompanyId { get; set; }
    }
}