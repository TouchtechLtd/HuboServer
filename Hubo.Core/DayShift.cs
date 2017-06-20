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

    public class DayShift : FullAuditedEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public bool isActive { get; set; }
    }
}
