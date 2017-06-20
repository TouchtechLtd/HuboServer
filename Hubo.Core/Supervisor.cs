

namespace Hubo
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using Abp.Domain.Entities.Auditing;
    using Hubo;
    using Users;

    public class Supervisor : FullAuditedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public long UserId { get; set; }
    }
}
