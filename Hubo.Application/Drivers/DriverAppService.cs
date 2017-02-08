using Abp.Domain.Repositories;
using Hubo.EntityFramework;
using Hubo.Respositories;
using System;
using System.Threading.Tasks;
using AutoMapper;
using Hubo.Drivers.Dto;
using System.Dynamic;
using System.Collections.Generic;
using Hubo.Companies.Dto;
using Hubo.Users;

namespace Hubo.Drivers
{
    public class DriverAppService
    {

        private DriverRepository _driverRepository;

        public DriverAppService()
        {
            _driverRepository = new EntityFramework.DriverRepository();
        }

        public int RegisterDriver(Driver driver)
        {
            int i = _driverRepository.RegisterDriver(driver);

            return i;
        }

        public User GetUserDetails(string usernameOrEmailAddress)
        {
            return _driverRepository.GetUserDetails(usernameOrEmailAddress);
        }

        public long GetDriverId(long id)
        {
            return _driverRepository.GetDriverId(id);
        }

        public Tuple<DriverOutput, int, string> GetDriverDetails(int userId)
        {
            Tuple<Driver, int, string> result = _driverRepository.GetDriverDetails(userId);
            if(result.Item2 == 1)
            {
                return Tuple.Create(Mapper.Map<Driver, DriverOutput>(result.Item1), result.Item2, result.Item3);
            }
            DriverOutput redundant = new DriverOutput();
            return Tuple.Create(redundant, result.Item2, result.Item3);
        }
    }
}
