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

        public virtual User User { get; set; }
        public virtual long UserId { get; set; }

        [MaxLength(20)]
        public string LicenceNo { get; set; }

        public int LicenceVersion { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePh { get; set; }

    }
}