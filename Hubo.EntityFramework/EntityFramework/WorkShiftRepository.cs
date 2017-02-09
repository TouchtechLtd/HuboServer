using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Hubo.EntityFramework
{
    public class WorkShiftRepository
    {
        public Tuple<int,string> StartShift(WorkShift shift)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    if (!ctx.DriverSet.Any(d => d.Id == shift.DriverId))
                    {
                        //Driver ID does not exist
                        return Tuple.Create(-1, "No Driver exists with the ID = " + shift.DriverId);
                    }

                    if (!ctx.CompanySet.Any(c => c.Id == shift.CompanyId))
                    {
                        return Tuple.Create(-1, "No Company exists with the ID = " + shift.CompanyId);
                    }

                    shift.isActive = true;
                    ctx.WorkShiftSet.Add(shift);
                    ctx.SaveChanges();
                    return Tuple.Create(shift.Id, "Success");
                }
                catch(Exception ex)
                {
                    return Tuple.Create(-1, ex.Message);
                }
                

            }
        }

        public Tuple<int, string> StopShift(WorkShift shift)
        {

            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    WorkShift currentShift = ctx.WorkShiftSet.Single<WorkShift>(s => s.Id == shift.Id);
                    if(currentShift.isActive == false)
                    {
                        return Tuple.Create(-1, "Shift has already ended");
                    }
                    currentShift.EndDate = shift.EndDate;
                    currentShift.EndLocationLat = shift.EndLocationLat;
                    currentShift.EndLocationLong = shift.EndLocationLong;
                    currentShift.isActive = false;
                    ctx.Entry(currentShift).State = EntityState.Modified;
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

   
        public Tuple<List<WorkShift>, string, int> GetWorkShifts(int driverId)
        {
            List<WorkShift> listOfWorkShifts = new List<WorkShift>();
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    if(!ctx.DriverSet.Any(d => d.Id == driverId))
                    {
                        return Tuple.Create(listOfWorkShifts, "No Driver exists with Driver ID = " + driverId, -1);
                    }

                    DateTime twoWeeksPrior = new DateTime();
                    twoWeeksPrior = DateTime.Now;
                    twoWeeksPrior = twoWeeksPrior.AddDays(-14);

                    listOfWorkShifts = (from b in ctx.WorkShiftSet
                                        where b.DriverId == driverId &&
                                        b.StartDate > twoWeeksPrior
                                        select b).ToList<WorkShift>();

                    return Tuple.Create(listOfWorkShifts, "Success", 1);
                }
                catch(Exception ex)
                {
                    return Tuple.Create(listOfWorkShifts, ex.Message, -1);
                }
            }
        }
    }
}
