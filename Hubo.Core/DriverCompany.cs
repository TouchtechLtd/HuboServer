﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo
{
    public class DriverCompany : FullAuditedEntity
    {
        public long DriverId { get; set; }
        public long CompanyId { get; set; }
    }
}
