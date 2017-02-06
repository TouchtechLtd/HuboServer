using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.EntityFramework
{
    public class NoteRepository
    {
        public Tuple<List<Note>, string, int> GetNotes(int shiftId)
        {
            List<Note> listOfNotes = new List<Note>();
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    if(!ctx.WorkShiftSet.Any(s => s.Id == shiftId))
                    {
                        return Tuple.Create(listOfNotes, "No Shift exists with the ID = " + shiftId, -1);
                    }

                    listOfNotes = (from b in ctx.NoteSet
                                   where b.ShiftId == shiftId
                                   select b).ToList<Note>();
                    return Tuple.Create(listOfNotes, "Success", 1);
                }
                catch(Exception ex)
                {
                    return Tuple.Create(listOfNotes, ex.Message, -1);
                }
            }
        }
    }
}
