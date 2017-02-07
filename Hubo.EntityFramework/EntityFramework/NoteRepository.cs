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

        public Tuple<int, string> InsertNote(Note note)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    if(!ctx.WorkShiftSet.Any(s => s.Id == note.ShiftId))
                    {
                        return Tuple.Create(-1, "No Shift exists with the ID = " + note.ShiftId);
                    }

                    if(note.BreakId > 0)
                    {
                        if(!ctx.BreakSet.Any(b => b.Id == note.BreakId))
                        {
                            return Tuple.Create(-1, "No Break exists with the ID = " + note.BreakId);
                        }
                    }

                    if(note.DrivingShiftId > 0)
                    {
                        if(!ctx.DrivingShiftSet.Any(s => s.Id == note.DrivingShiftId))
                        {
                            return Tuple.Create(-1, "No Drive Shift exists with the ID = " + note.DrivingShiftId);
                        }
                    }

                    ctx.NoteSet.Add(note);
                    ctx.SaveChanges();
                    return Tuple.Create(note.Id, "Success");

                }
                catch(Exception ex)
                {
                    return Tuple.Create(-1, ex.Message);
                }
            }
        }
    }
}
