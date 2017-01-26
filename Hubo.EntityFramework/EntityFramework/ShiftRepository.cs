using Hubo.ApiRequestClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.EntityFramework
{
    public class ShiftRepository
    {
        public Tuple<int,string> StartShift(ShiftStartRequest shift)
        {
            Shift startShift = shift.Shift;
            Note startNote = shift.Note;
            using (HuboDbContext ctx = new HuboDbContext())
            {
                if (!ctx.DriversSet.Any(d => d.Id == startShift.DriverId))
                {
                    //Driver ID does not exist
                    return Tuple.Create(-1, "Driver ID does not exist");
                }

                if (!ctx.VehiclesSet.Any(v => v.Id == startShift.VehicleId))
                {
                    //Vehicle ID does not exist
                    return Tuple.Create(-2, "Vehicle ID does not exist");
                }

                //TODO: Code to make sure all previous shifts were closed before starting a new one

                try
                {

                    ctx.NoteSet.Add(startNote);
                    ctx.SaveChanges();

                    ShiftBreakNote shiftBreakNote = new ShiftBreakNote();
                    shiftBreakNote.IsBreak = false;
                    shiftBreakNote.NoteId = startNote.Id;
                    shiftBreakNote.StandAloneNote = false;
                    ctx.ShiftBreakSet.Add(shiftBreakNote);
                    ctx.SaveChanges();

                    startShift.ShiftBreakNoteStartId = shiftBreakNote.Id;
                    ctx.Shifts.Add(startShift);
                    ctx.SaveChanges();

                    shiftBreakNote.BreakShiftId = startShift.Id;
                    ctx.Entry(shiftBreakNote).Property(e => e.BreakShiftId).IsModified = true;                    
                    ctx.SaveChanges();

                    return Tuple.Create(startShift.Id, "Success");
                }
                catch(Exception ex)
                {
                    return Tuple.Create(-3, ex.Message);
                }
            }
        }

        public Tuple<int,string> StopShift(ShiftStopRequest shift)
        {
            long shiftId = shift.Id;
            Note stopNote = shift.Note;

            //TODO: Check if shift id exists
            using (HuboDbContext ctx = new HuboDbContext())
            {
                if(!ctx.Shifts.Any(s => s.Id == shiftId))
                {
                    //Shift ID does not exist
                    return Tuple.Create(-1, "Shift ID does not exist");
                }
                try
                {
                    ctx.NoteSet.Add(stopNote);
                    ctx.SaveChanges();

                    ShiftBreakNote shiftBreakNote = new ShiftBreakNote();
                    shiftBreakNote.IsBreak = false;
                    shiftBreakNote.NoteId = stopNote.Id;
                    shiftBreakNote.BreakShiftId = shiftId;
                    shiftBreakNote.StandAloneNote = false;
                    ctx.ShiftBreakSet.Add(shiftBreakNote);
                    ctx.SaveChanges();

                    Shift currentShift = ctx.Shifts.Single(s => s.Id == shiftId);
                    currentShift.ShiftBreakNoteStopId = shiftBreakNote.Id;
                    ctx.Entry(currentShift).Property(e => e.ShiftBreakNoteStopId).IsModified = true;                    
                    ctx.SaveChanges();

                    return Tuple.Create(1, "Success");
                }
                catch(Exception ex)
                {
                    return Tuple.Create(-2, ex.Message);
                }
                
                
            }

        }

        public Tuple<int,string> StartBreak(BreakStartRequest startBreak)
        {
            long shiftId = startBreak.ShiftId;
            Note startBreakNote = startBreak.Note;

            using (HuboDbContext ctx = new HuboDbContext())
            {
                if (!ctx.Shifts.Any(s => s.Id == shiftId))
                {
                    //Shift ID does not exist
                    return Tuple.Create(-1, "Shift ID does not exist");
                }

                //TODO: Code to make sure all previous breaks were closed before starting a new one

                try
                {
                    ctx.NoteSet.Add(startBreakNote);
                    ctx.SaveChanges();

                    Break newBreak = new Break();
                    newBreak.ShiftId = shiftId;
                    ctx.Breaks.Add(newBreak);
                    ctx.SaveChanges();

                    ShiftBreakNote shiftBreak = new ShiftBreakNote();
                    shiftBreak.IsBreak = true;
                    shiftBreak.NoteId = startBreakNote.Id;
                    shiftBreak.StandAloneNote = false;
                    shiftBreak.BreakShiftId = newBreak.Id;
                    ctx.ShiftBreakSet.Add(shiftBreak);
                    ctx.SaveChanges();

                    newBreak.ShiftBreakNoteStartId = shiftBreak.Id;
                    ctx.Entry(newBreak).Property(e => e.ShiftBreakNoteStartId).IsModified = true;                    
                    ctx.SaveChanges();
                    return Tuple.Create(newBreak.Id, "Success");
                }
                catch(Exception ex)
                {
                    return Tuple.Create(-2, ex.Message);
                }

            }
        }

        public Tuple<int,string> EndBreak(BreakEndRequest endBreak)
        {
            long breakId = endBreak.BreakId;
            Note endBreakNote = endBreak.Note;

            using (HuboDbContext ctx = new HuboDbContext())
            {
                if(!ctx.Breaks.Any(b => b.Id == breakId))
                {
                    //Break ID does not exist
                    return Tuple.Create(-1, "Break ID does not exist");
                }

                try
                {
                    ShiftBreakNote shiftBreak = new ShiftBreakNote();
                    ctx.NoteSet.Add(endBreakNote);
                    ctx.SaveChanges();

                    shiftBreak.IsBreak = true;
                    shiftBreak.NoteId = endBreakNote.Id;
                    ctx.ShiftBreakSet.Add(shiftBreak);               
                    ctx.SaveChanges();

                    Break currentBreak = ctx.Breaks.Single(b => b.Id == breakId);
                    currentBreak.ShiftBreakNoteStopId = shiftBreak.Id;
                    ctx.SaveChanges();

                    shiftBreak.BreakShiftId = currentBreak.Id;
                    ctx.Entry(shiftBreak).Property(e => e.BreakShiftId).IsModified = true;                    
                    ctx.SaveChanges();

                    return Tuple.Create(1, "Success");
                }
                catch(Exception ex)
                {
                    return Tuple.Create(-2, ex.Message);
                }
            }

        }
    }
}
