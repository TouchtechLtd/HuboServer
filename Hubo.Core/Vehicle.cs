namespace Hubo
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using Abp.Domain.Entities.Auditing;
    using System.ComponentModel.DataAnnotations;

    public class Vehicle : FullAuditedEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public string RegistrationNo { get; set; }
        public string MakeModel { get; set; }
        public int StartingOdometer { get; set; }
        public int CurrentOdometer { get; set; }
        public long CompanyId { get; set; }
    }
}