using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.EntityFramework
{
    public class BreakRepository
    {
        public Tuple<List<Break>, string, int> GetBreaks(int shiftId)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                List<Break> listOfBreaks = new List<Break>();
                
                try
                {
                    if(!ctx.WorkShiftSet.Any(s => s.Id == shiftId))
                    {
                        return Tuple.Create(listOfBreaks, "No Shift exists with ID = " + shiftId, -1);
                    }

                    listOfBreaks = (from b in ctx.BreakSet
                                    where b.ShiftId == shiftId
                                    select b).ToList<Break>();

                    return Tuple.Create(listOfBreaks, "Success", 1);

                }
                catch(Exception ex)
                {
                    return Tuple.Create(listOfBreaks, ex.Message, -1);
                }
            }
        }
    }
}
