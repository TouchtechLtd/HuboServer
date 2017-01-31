using Abp.Collections.Extensions;
using Hubo.Respositories;
using Hubo.Users;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hubo;
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

        public Driver GetDriverByUserId(long userId)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    Driver driverResponse = ctx.DriverSet.Single(p => p.UserId == userId);
                    return driverResponse;
                }
                catch (Exception ex)
                {
                    return null;
                }
                
            }
        }

        public List<Vehicle> GetVehiclesByCompanyId(int id)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                List<Vehicle> listOfVehicles = (from v in ctx.VehicleSet
                                                where v.CompanyId.Equals(id)
                                                select v).ToList<Vehicle>();
                return listOfVehicles;
            }
        }

        public List<Company> GetCompaniesByDriverId(int id)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                List<Company> listOfCompanies = (from dc in ctx.DriverCompanySet
                                                        join c in ctx.CompanySet on dc.CompanyId equals c.Id
                                                        where dc.DriverId == id
                                                        select c).ToList();
                return listOfCompanies;
            }
        }

        //public LoginResponse GetDetails(long userId)
        //{
        //    using (HuboDbContext ctx = new HuboDbContext())
        //    {
        //        LoginResponse response = new LoginResponse();
        //        try
        //        {
        //            //Code to get all user info properly, currently saying none exists
        //            //User userresponse = ctx.Users.Where(p => p.EmailAddress == userEmail).FirstOrDefault();
        //            //List<User> users = (from u in ctx.Users
        //            //                 where u.Id.Equals(3)
        //            //                 select u).ToList<User>();
        //            //response.UserId = 2;
        //            Driver driverResponse = ctx.DriversSet.Single(p => p.UserId == userId);                    
        //            response.Driver = driverResponse;                    
        //            //Code to get all company/Driver info
        //            List<Company> listOfCompaniesDrivers =  (from dc in ctx.DriverCompaniesSet
        //                                                     join c in ctx.CompaniesSet on dc.CompanyId equals c.Id
        //                                                     where dc.DriverId == driverResponse.Id
        //                                                     select c).ToList();
        //            List<CompanyAndVehicles> companyVehicleResponse = new List<CompanyAndVehicles>();
                    
        //            foreach(Company company in listOfCompaniesDrivers)
        //            {
        //                List<Vehicle> vehicles = new List<Vehicle>();
        //                CompanyAndVehicles companyAndVehicles = new CompanyAndVehicles();

        //                vehicles = (from v in ctx.VehiclesSet
        //                            where v.CompanyId == company.Id
        //                            select v).ToList<Vehicle>();
        //                companyAndVehicles.Company = company;
        //                companyAndVehicles.Vehicles = vehicles;
        //                companyVehicleResponse.Add(companyAndVehicles);
        //            }
        //            response.CompaniesAndVehicle = companyVehicleResponse;
                    
        //            return response;
        //        }
        //        catch (Exception ex)
        //        {
        //            return null;
        //        }


                
        //    }
        //}

        public int RegisterDriver(Driver driver)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                //ctx.DriverSet.Add(driver);

                //// functionality of this code should be to check if email exists in User table and if not create the user
                //// then save driver as Driver using the created user ID
                //bool userExists = checkUserEmail(driver.Email, ctx);

                //// if user doesn't exist need to register them first then go on to save them as a driver
                //if(!userExists)
                //{
                //    // createUser();
                //}

                //else
                //{
                //    //Matching User was found, thus email is in use, thus invalid
                //    return -1;
                //}
                
                //try
                //{
                //    int result = 0;
                //    // check licence number doesn't already exist
                //    if (ctx.DriversSet.Any(o => o.LicenceNo == driver.LicenceNo))
                //    {
                //        // Match!
                //        result = -1;
                //    } else
                //    {
                //        result = ctx.SaveChanges();
                //    }
                    
                //    return result;
                //}
                //catch (Exception ex) {
                //    string x = ex.Message;

                //    return 0;
                //}
                
            }
            return 0;
        }

        public bool CreateUser()
        {
            return false;
        }
    }
}
