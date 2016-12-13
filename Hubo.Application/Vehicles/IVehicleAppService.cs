using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.Vehicles
{
    public interface IVehicleAppService : IApplicationService
    {


        Task RegisterVehicle(Hubo.Vehicles.DTo.CreateVehicleInput input);
    }
}
