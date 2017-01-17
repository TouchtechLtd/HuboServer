using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.EntityFramework
{
    public class ShiftRepository
    {
        public int StartShift(Shift shift)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    ctx.Shifts.Add(shift);
                    ctx.SaveChanges();
                    return shift.Id;
                }
                catch(Exception ex)
                {
                    return -1;
                }
            }
        }

        public int StopShift(Shift endShift)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    if (endShift.Id == 0)
                    {
                        return -1;
                    }
                    Shift updateShift;
                    updateShift = ctx.Shifts.Where(s => s.Id == endShift.Id).FirstOrDefault<Shift>();
                    updateShift.End_location_lat = endShift.End_location_lat;
                    updateShift.End_location_long = endShift.End_location_long;
                    updateShift.EndDateTime = endShift.EndDateTime;
                    ctx.Entry(updateShift).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                    return 1;
                }
                catch(Exception ex)
                {
                    return -2;
                }
                
            }
        }
    }
}
