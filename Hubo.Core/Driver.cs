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
        public long CompanyId { get; set; }
        public long UserId { get; set; }
    }
}