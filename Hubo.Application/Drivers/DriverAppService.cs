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

        public LoginResponse GetDetails(long userId)
        {
            Driver driver = _driverRepository.GetDriverByUserId(userId);
            LoginResponse response = new LoginResponse();
            if(driver!=null)
            {
                DriverOutput driverOutput = Mapper.Map<Driver, Dto.DriverOutput>(driver);
                response.Driver = driverOutput;
            }

            else
            {
                return null;
            }


            List<Company> listOfCompanies = _driverRepository.GetCompaniesByDriverId(driver.Id);
            if (listOfCompanies != null)
            {
                List<CompanyAndVehicles> listOfCompaniesAndTheirVehicles = new List<CompanyAndVehicles>();
                foreach(Company company in listOfCompanies)
                {
                    CompanyAndVehicles companyAndTheirVehicles = new CompanyAndVehicles();
                    CompanyOutput companyOutput = Mapper.Map<Company, CompanyOutput>(company);
                    companyAndTheirVehicles.Company = companyOutput;
                    List<Vehicle> listOfVehicles = _driverRepository.GetVehiclesByCompanyId(company.Id);
                    List<object> vehicles = new List<object>();
                    companyAndTheirVehicles.Vehicles = vehicles;                    
                    foreach(Vehicle vehicle in listOfVehicles)
                    {
                        VehicleOutput vehicleOutput = Mapper.Map<Vehicle, VehicleOutput>(vehicle);
                        companyAndTheirVehicles.Vehicles.Add(vehicleOutput);
                    }
                    listOfCompaniesAndTheirVehicles.Add(companyAndTheirVehicles);
                }
                response.CompaniesAndVehicle = listOfCompaniesAndTheirVehicles;
            }
            
            return response;
        }

    }
}
