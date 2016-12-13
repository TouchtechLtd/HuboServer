using Hubo.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.Vehicles
{
    public class VehicleAppService
    {
        private VehicleRepository _vehicleRepository;

        public VehicleAppService()
        {
            _vehicleRepository = new EntityFramework.VehicleRepository();
        }

        public int RegisterVehicle(Vehicle vehicle)
        {
            int i = _vehicleRepository.RegisterVehicle(vehicle);

            return i;
        }
    }
}
