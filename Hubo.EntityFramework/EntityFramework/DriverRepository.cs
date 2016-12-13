using Hubo.Respositories;
using Hubo.Users;
using System;
using System.Collections.Generic;
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
    }
}
