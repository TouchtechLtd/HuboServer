using Abp.Domain.Repositories;
using Hubo.EntityFramework;
using Hubo.Respositories;
using System;
using System.Threading.Tasks;

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
    }
}
