namespace Hubo
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using Abp.Domain.Entities.Auditing;
    using System.ComponentModel.DataAnnotations;

    public class Vehicle 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RegistrationNo { get; set; }
        public string MakeModel { get; set; }
        public string FleetNumber { get; set; }
        public int CompanyId { get; set; }
        public bool IsManuallyEntered { get; set; }
    }
}