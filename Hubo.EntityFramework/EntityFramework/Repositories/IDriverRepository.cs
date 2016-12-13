using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.Respositories
{
    public interface IDriverRepository : IRepository
    {
        int RegisterDriver(Driver driver);
    }
}
