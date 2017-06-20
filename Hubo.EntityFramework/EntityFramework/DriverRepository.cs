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

        public Tuple<Driver,int,string> GetDriverDetails(int userId)
        {
            Driver currentDriver = new Driver();
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    currentDriver = ctx.DriverSet.Single<Driver>(d => d.UserId == userId);
                    return Tuple.Create(currentDriver, 1, "Success");
                }
                catch(Exception ex)
                {
                    return Tuple.Create(currentDriver, -1, ex.Message) ;
                }
            }
        }

        public List<Licence> GetLicences(int driverId)
        {
            List<Licence> listOfLicences = new List<Licence>();
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    listOfLicences = (from licences in ctx.LicenceSet
                                      where licences.DriverId == driverId
                                      select licences).ToList<Licence>();
                    return listOfLicences;
                }
                catch(Exception ex)
                {
                    return listOfLicences;
                }
            }
        }

        public List<DrivingShift> GetDrivingShifts(List<long> listOfWorkShiftIds)
        {
            List<DrivingShift> listOfDrivingShifts = new List<DrivingShift>();
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    listOfDrivingShifts = ctx.DrivingShiftSet.Where(c => listOfWorkShiftIds.Contains(c.ShiftId)).ToList<DrivingShift>();
                    return listOfDrivingShifts;
                }
                catch(Exception ex)
                {
                    return listOfDrivingShifts;
                }
            }
        }

        public List<Note> GetNotes(List<long> listOfWorkShiftIds)
        {
            List<Note> listOfNotes = new List<Note>();
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    listOfNotes = ctx.NoteSet.Where(c => listOfWorkShiftIds.Contains(c.ShiftId)).ToList<Note>();
                    return listOfNotes;
                }
                catch(Exception ex)
                {
                    return listOfNotes;
                }
            }
        }

        public List<Break> GetBreaks(List<long> listOfWorkShiftIds)
        {
            List<Break> listOfBreaks = new List<Break>();
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    listOfBreaks = ctx.BreakSet.Where(c => listOfWorkShiftIds.Contains(c.ShiftId)).ToList<Break>();
                    return listOfBreaks;
                }
                catch (Exception ex)
                {
                    return listOfBreaks;
                }
            }
        }

        public List<WorkShift> GetShiftFromLastLongBreak(int driverId)
        {
            List<WorkShift> listOfWorkShifts = new List<WorkShift>();
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    WorkShift lastWorkShift = ctx.WorkShiftSet.Where(p => p.TimeSinceLastShiftMins >= 1440 && p.DriverId == driverId).OrderByDescending(p => p.Id).First();

                    listOfWorkShifts = ctx.WorkShiftSet.Where(p => p.DriverId == driverId && p.StartDate >= lastWorkShift.StartDate).ToList<WorkShift>();
                    return listOfWorkShifts;
                }
                catch (Exception ex)
                {
                    return listOfWorkShifts;
                }
            }
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
