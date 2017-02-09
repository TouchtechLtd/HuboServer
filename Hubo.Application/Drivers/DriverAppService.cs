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

        public Tuple<DriverOutput,List<LicenceOutputDto>, int, string> GetDriverDetails(int userId)
        {
            List<Licence> listOfLicences = new List<Licence>();
            List<LicenceOutputDto> listOfLicenceDtos = new List<LicenceOutputDto>();

            Tuple<Driver, int, string> driverDetailsresult = _driverRepository.GetDriverDetails(userId);

            listOfLicences = _driverRepository.GetLicences(driverDetailsresult.Item1.Id);
            foreach(Licence licence in listOfLicences)
            {
                listOfLicenceDtos.Add(Mapper.Map<Licence, LicenceOutputDto>(licence));
            }
            return Tuple.Create(Mapper.Map<Driver, DriverOutput>(driverDetailsresult.Item1), listOfLicenceDtos, driverDetailsresult.Item2, driverDetailsresult.Item3);

        }
    }
}
