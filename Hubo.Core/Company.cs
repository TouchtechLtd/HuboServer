namespace Hubo
{
    using System;
    using System.Linq;
    using Abp.Domain.Entities.Auditing;


    public class Company : FullAuditedEntity
    {
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PostCode { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Contact { get; set; }
        public string ContactEmail { get; set; }
    }
}
