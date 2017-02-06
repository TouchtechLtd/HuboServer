﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hubo
{
    public class DrivingShift : FullAuditedEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }
        public long ShiftId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool State { get; set; }
        public long VehicleId { get; set; }
    }
}
