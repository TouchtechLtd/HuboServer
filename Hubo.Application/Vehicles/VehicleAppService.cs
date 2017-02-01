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

        public int RegisterVehicle(Vehicle vehicle)
        {
            int i = _vehicleRepository.RegisterVehicle(vehicle);

            return i;
        }

        public Tuple<List<VehicleOutput>,string,int> GetVehicles(int companyId)
        {
            Tuple<List<Vehicle>, string, int> result = _vehicleRepository.GetVehicles(companyId);
            List<VehicleOutput> listOfDtoVehicles = new List<VehicleOutput>();
            foreach(Vehicle vehicle in result.Item1)
            {
                listOfDtoVehicles.Add(Mapper.Map<Vehicle, VehicleOutput>(vehicle));
            }
            return Tuple.Create(listOfDtoVehicles, result.Item2, result.Item3);
        }
    }
}
