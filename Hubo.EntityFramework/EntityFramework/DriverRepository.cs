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

        public long GetDriverId(long id)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    Driver driver = ctx.DriverSet.Single<Driver>(d => d.UserId == id);
                    return driver.Id;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public User GetUserDetails(string usernameOrEmailAddress)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    User test = ctx.Users.Single<User>(b => b.EmailAddress == usernameOrEmailAddress);
                    return test;
                }
                catch(Exception ex)
                {
                    return null;
                }
                
            }
        }

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
