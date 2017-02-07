using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.EntityFramework
{
    public class BreakRepository
    {
        public Tuple<List<Break>, string, int> GetBreaks(int driveShiftId)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                List<Break> listOfBreaks = new List<Break>();
                
                try
                {
                    if(!ctx.DrivingShiftSet.Any(s => s.Id == driveShiftId))
                    {
                        return Tuple.Create(listOfBreaks, "No Drive Shift exists with ID = " + driveShiftId, -1);
                    }

                    listOfBreaks = (from b in ctx.BreakSet
                                    where b.DriveShiftId == driveShiftId
                                    select b).ToList<Break>();

                    return Tuple.Create(listOfBreaks, "Success", 1);

                }
                catch(Exception ex)
                {
                    return Tuple.Create(listOfBreaks, ex.Message, -1);
                }
            }
        }

        public Tuple<int, string> StartBreak(Break newBreak)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    if(!ctx.WorkShiftSet.Any(s => s.Id == newBreak.DriveShiftId))
                    {
                        return Tuple.Create(-1, "No Drive Shift exists for ID = " + newBreak.DriveShiftId);
                    }

                    newBreak.State = true;
                    ctx.BreakSet.Add(newBreak);
                    ctx.SaveChanges();
                    return Tuple.Create(newBreak.Id, "Success");

                }
                catch (Exception ex)
                {
                    return Tuple.Create(-1, ex.Message);
                }
            }
        }

        public Tuple<int, string> StopBreak(int breakId)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    Break currentBreak = ctx.BreakSet.Single<Break>(b => b.Id == breakId);
                    if(currentBreak.State == false)
                    {
                        return Tuple.Create(-1, "Break has already ended");
                    }
                    currentBreak.State = false;
                    ctx.Entry(currentBreak).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                    return Tuple.Create(1, "Success");
                }
                catch(ArgumentNullException ex)
                {
                    return Tuple.Create(-1, ex.Message);
                }
                catch(Exception ex)
                {
                    return Tuple.Create(-1, ex.Message);
                }
            }
        }
    }
}
