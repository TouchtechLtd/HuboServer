using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.Drivers.Dto
{
    [AutoMap(typeof(Licence))]
    public class LicenceOutputDto
    {
        public string Class { get; set; }
        public string Endorsement { get; set; }
    }
}
