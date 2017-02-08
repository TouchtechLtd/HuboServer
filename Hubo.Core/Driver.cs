namespace Hubo
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Abp.Domain.Entities.Auditing;
    using System.ComponentModel.DataAnnotations.Schema;
    using Hubo;
    using Users;
    using System.ComponentModel.DataAnnotations;

    public class Driver : FullAuditedEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public long UserId { get; set; }
        public int PhoneNumber { get; set; }
        public string LicenceNumber { get; set; }
        public string LicenceVersion { get; set; }
        public string LicenceEndorsement { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}