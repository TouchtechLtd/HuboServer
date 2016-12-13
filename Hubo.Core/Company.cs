namespace Hubo
{
    using System;
    using System.Linq;
    using Abp.Domain.Entities.Auditing;


    public class Company : FullAuditedEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
    }
}