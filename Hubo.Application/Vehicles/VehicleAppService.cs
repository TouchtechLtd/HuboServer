using Hubo.Vehicles.Dto;
using Hubo.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Hubo.Vehicles
{
    public class VehicleAppService
    {
        private VehicleRepository _vehicleRepository;

        public VehicleAppService()
        {
            _vehicleRepository = new EntityFramework.VehicleRepository();
        }

        public Tuple<int,string> RegisterVehicle(Vehicle vehicle)
        {
            vehicle.RegistrationNo = vehicle.RegistrationNo.ToUpper();
            return _vehicleRepository.RegisterVehicle(vehicle);
        }

        public Tuple<List<VehicleOutput>, string, int> GetVehiclesByDriver(int driverId)
        {
            Tuple<List<Vehicle>, string, int> result = _vehicleRepository.GetVehiclesByDriver(driverId);
            List<VehicleOutput> listOfDtoVehicles = new List<VehicleOutput>();
            foreach (Vehicle vehicle in result.Item1)
            {
                listOfDtoVehicles.Add(Mapper.Map<Vehicle, VehicleOutput>(vehicle));
            }
            return Tuple.Create(listOfDtoVehicles, result.Item2, result.Item3);
        }
    }
}
