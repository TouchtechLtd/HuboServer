using Hubo.Respositories;
using Hubo.Users;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.EntityFramework
{
    public class DriverRepository : IDriverRepository
    {

        private bool checkUserEmail(string email, HuboDbContext ctx)
        {
            User user = new User();
            user.EmailAddress = email;
            //ctx.UserSet.Add(user);
            /*
            try
            {
                bool result = false;
                // check licence number doesn't already exist
                if (ctx.UserSet.Any(o => o.EmailAddress == user.EmailAddress))
                {
                    // Match!
                    result = true;
                }
                    
                return result;
            }
            catch (Exception ex)
            {
                string x = ex.Message;

                return false;
            }
            */

            return false;
        }

        public LoginResponse GetDetails(string userEmail)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                LoginResponse response = new LoginResponse();
                try
                {
                    //TODO: Code to get all user info properly, currently saying none exists
                    //User userResponse = ctx.Users.Where(p => p.EmailAddress==userEmail).FirstOrDefault();
                    //response.UserId = userResponse.Id;
                    //Driver driverResponse = ctx.DriversSet.Single(p => p.UserId == userResponse.Id);

                    if (userEmail=="ben@triotech.co.nz")
                    {
                        response.UserId = 4;
                    }
                    else
                    {
                        return response;
                    }
                    Driver driverResponse = ctx.DriversSet.Single(p => p.UserId == response.UserId);

                    //TODO: Code to get all driver info
                    response.DriverId = driverResponse.Id;
                    response.DriverFirstName = driverResponse.FirstName;
                    response.DriverSurname = driverResponse.LastName;
                    response.DriverEmail = driverResponse.Email;
                    response.LicenceNo = driverResponse.LicenceNo;
                    response.LicenceVersion = driverResponse.LicenceVersion;
                    response.MobilePh = Int32.Parse(driverResponse.MobilePh);


                    //TODO: Code to get all company/Driver info
                    IQueryable<DriverCompany> driverCompanyResponse;
                    driverCompanyResponse = from b in ctx.DriverCompaniesSet
                                            where b.DriverId.Equals(driverResponse.Id)
                                            select b;

                    List<DriverCompany> listCompanies = driverCompanyResponse.ToList<DriverCompany>();

                    //TODO: Code to get all company info
                    List<Company> listOfCompanies = new List<Company>();
                    foreach(DriverCompany driverCompany in listCompanies)
                    {
                        Company companyResponse = new Company();
                        companyResponse = ctx.CompaniesSet.Single(p => p.Id.Equals(driverCompany.CompanyId));
                        listOfCompanies.Add(companyResponse);
                    }

                    List<CompanyAndVehicles> listOfCompaniesAndVehicles = new List<CompanyAndVehicles>();

                    //TODO: Code to get all vehicle info
                    List<Vehicle> listOfVehicles = new List<Vehicle>();
                    foreach(Company company in listOfCompanies)
                    {

                        CompanyAndVehicles companyAndVehicles = new CompanyAndVehicles();
                        IQueryable<Vehicle> vehicleResponse;
                        vehicleResponse = from b in ctx.VehiclesSet
                                          where b.CompanyId.Equals(company.Id)
                                          select b;
                        companyAndVehicles.Company = company;
                        companyAndVehicles.Vehicles = vehicleResponse.ToList<Vehicle>();
                        listOfCompaniesAndVehicles.Add(companyAndVehicles);

                    }
                    response.CompaniesAndVehicle = listOfCompaniesAndVehicles;
                    return response;
                }
                catch (Exception ex)
                {
                    return response;
                }


                
            }
        }

        public int RegisterDriver(Driver driver)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                ctx.DriversSet.Add(driver);

                // functionality of this code should be to check if email exists in User table and if not create the user
                // then save driver as Driver using the created user ID
                bool userExists = checkUserEmail(driver.Email, ctx);

                // if user doesn't exist need to register them first then go on to save them as a driver
                if(!userExists)
                {
                    // createUser();
                }

                else
                {
                    //Matching User was found, thus email is in use, thus invalid
                    return -1;
                }
                
                try
                {
                    int result = 0;
                    // check licence number doesn't already exist
                    if (ctx.DriversSet.Any(o => o.LicenceNo == driver.LicenceNo))
                    {
                        // Match!
                        result = -1;
                    } else
                    {
                        result = ctx.SaveChanges();
                    }
                    
                    return result;
                }
                catch (Exception ex) {
                    string x = ex.Message;

                    return 0;
                }
                
            }
        }

        public bool CreateUser()
        {
            return false;
        }
    }
}
