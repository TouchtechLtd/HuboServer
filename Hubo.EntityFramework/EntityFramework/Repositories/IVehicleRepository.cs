using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Hubo.EntityFramework.Repositories
{
    public interface IVehicleRepository : IRepository
    {
        int RegisterVehicle(Vehicle vehicle);
    }
}
