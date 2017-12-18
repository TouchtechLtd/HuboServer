using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Hubo.EntityFramework
{
    public class BreakRepository
    {

        //NOTE: For driveShift id

        //public Tuple<List<Break>, string, int> GetBreaks(int shiftId)
        //{
        //    using (HuboDbContext ctx = new HuboDbContext())
        //    {
        //        List<Break> listOfBreaks = new List<Break>();

        //        try
        //        {
        //            if(!ctx.DrivingShiftSet.Any(s => s.Id == shiftId))
        //            {
        //                return Tuple.Create(listOfBreaks, "No Shift exists with ID = " + shiftId, -1);
        //            }

        //            listOfBreaks = (from b in ctx.BreakSet
        //                            where b.ShiftId == shiftId
        //                            select b).ToList<Break>();

        //            return Tuple.Create(listOfBreaks, "Success", 1);

        //        }
        //        catch(Exception ex)
        //        {
        //            return Tuple.Create(listOfBreaks, ex.Message, -1);
        //        }
        //    }
        //}


        public Tuple<List<Break>, string, int> GetBreaks(int shiftId)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                List<Break> listOfBreaks = new List<Break>();

                try
                {
                    if (!ctx.WorkShiftSet.Any<WorkShift>(d => d.Id == shiftId))
                    {
                        return Tuple.Create(listOfBreaks, "No Shift exists with ID = " + shiftId, -1);
                    }

                    listOfBreaks = (from breaks in ctx.BreakSet
                                    join shift in ctx.WorkShiftSet on breaks.ShiftId equals shift.Id
                                    where shift.Id == shiftId
                                    select breaks).ToList<Break>();
                    return Tuple.Create(listOfBreaks, "Success", 1);

                }
                catch (Exception ex)
                {
                    return Tuple.Create(listOfBreaks, ex.Message, -1);
                }
            }
        }

        public List<Break> GetBreaksList(int shiftId)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                List<Break> listOfBreaks = new List<Break>();
                listOfBreaks = (from breaks in ctx.BreakSet
                                join shift in ctx.WorkShiftSet on breaks.ShiftId equals shift.Id
                                where shift.Id == shiftId
                                select breaks).ToList<Break>();
                return listOfBreaks;

            }
        }

        public Tuple<int, string> StartBreak(Break newBreak)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    if (!ctx.WorkShiftSet.Any(s => s.Id == newBreak.ShiftId))
                    {
                        return Tuple.Create(-1, "No Shift exists for ID = " + newBreak.ShiftId);
                    }

                    if (ctx.BreakSet.Any(b => b.isActive == true && b.ShiftId == newBreak.ShiftId))
                    {
                        return Tuple.Create(-1, "A break is already active");
                    }

                    newBreak.isActive = true;
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

        public Tuple<int, string> StopBreak(Break stopBreak)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    Break currentBreak = ctx.BreakSet.Single<Break>(b => b.Id == stopBreak.Id);
                    if (currentBreak.isActive == false)
                    {
                        return Tuple.Create(-1, "Break has already ended");
                    }
                    currentBreak.isActive = false;
                    currentBreak.StopBreakDateTime = stopBreak.StopBreakDateTime;
                    currentBreak.StopBreakLocation = stopBreak.StopBreakLocation;
                    currentBreak.EndNote = stopBreak.EndNote;
                    ctx.Entry(currentBreak).State = EntityState.Modified;
                    ctx.SaveChanges();
                    return Tuple.Create(1, "Success");
                }
                catch (ArgumentNullException ex)
                {
                    return Tuple.Create(-1, ex.Message);
                }
                catch (Exception ex)
                {
                    return Tuple.Create(-1, ex.Message);
                }
            }
        }
    }
}
