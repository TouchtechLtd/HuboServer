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
        //public int StartShift(Shift shift)
        //{
        //    using (HuboDbContext ctx = new HuboDbContext())
        //    {
        //        try
        //        {
        //            ctx.Shifts.Add(shift);
        //            ctx.SaveChanges();
        //            return shift.Id;
        //        }
        //        catch(Exception ex)
        //        {
        //            return -1;
        //        }
        //    }
        //}

        //public int StopShift(Shift endShift)
        //{
        //    using (HuboDbContext ctx = new HuboDbContext())
        //    {
        //        try
        //        {
        //            if (endShift.Id == 0)
        //            {
        //                return -1;
        //            }
        //            Shift updateShift;
        //            updateShift = ctx.Shifts.Where(s => s.Id == endShift.Id).FirstOrDefault<Shift>();
        //            updateShift.End_location_lat = endShift.End_location_lat;
        //            updateShift.End_location_long = endShift.End_location_long;
        //            updateShift.EndDateTime = endShift.EndDateTime;
        //            ctx.Entry(updateShift).State = System.Data.Entity.EntityState.Modified;
        //            ctx.SaveChanges();
        //            return 1;
        //        }
        //        catch(Exception ex)
        //        {
        //            return -2;
        //        }

        //    }
        //}

        //public int StartBreak(Break shiftBreak)
        //{
        //    using (HuboDbContext ctx = new HuboDbContext())
        //    {
        //        try
        //        {
        //            ctx.Breaks.Add(shiftBreak);
        //            ctx.SaveChanges();
        //            return shiftBreak.Id;
        //        }
        //        catch(Exception ex)
        //        {
        //            return -1;
        //        }
        //    }
        //}

        //public int EndBreak(Break shiftBreak)
        //{
        //    using (HuboDbContext ctx = new HuboDbContext())
        //    {
        //        try
        //        {
        //            if (shiftBreak.Id == 0)
        //            {
        //                return -1;
        //            }
        //            Break updateBreak;
        //            updateBreak = ctx.Breaks.Where(s => s.Id == shiftBreak.Id).FirstOrDefault<Break>();
        //            updateBreak.EndBreakTime = shiftBreak.EndBreakTime;
        //            ctx.Entry(updateBreak).State = System.Data.Entity.EntityState.Modified;
        //            ctx.SaveChanges();
        //            return 1;
        //        }
        //        catch (Exception ex)
        //        {
        //            return -2;
        //        }

        //    }
        //}
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
                try
                {
                    ShiftBreakNote shiftBreakNote = new ShiftBreakNote();
                    ctx.NoteSet.Add(startNote);
                    ctx.SaveChanges();
                    shiftBreakNote.NoteId = startNote.Id;
                    shiftBreakNote.StandAloneNote = false;
                    ctx.ShiftBreakSet.Add(shiftBreakNote);
                    ctx.SaveChanges();
                    startShift.ShiftBreakNoteStartId = shiftBreakNote.Id;
                    ctx.Shifts.Add(startShift);
                    ctx.SaveChanges();
                    shiftBreakNote.BreakShiftId = startShift.Id;
                    var entry = ctx.Entry(shiftBreakNote);
                    entry.Property(e => e.BreakShiftId).IsModified = true;
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
                    ShiftBreakNote shiftBreakNote = new ShiftBreakNote();
                    ctx.NoteSet.Add(stopNote);
                    ctx.SaveChanges();
                    shiftBreakNote.NoteId = stopNote.Id;
                    shiftBreakNote.BreakShiftId = shiftId;
                    shiftBreakNote.StandAloneNote = false;
                    ctx.ShiftBreakSet.Add(shiftBreakNote);
                    ctx.SaveChanges();

                    Shift currentShift = ctx.Shifts.Single(s => s.Id == shiftId);
                    currentShift.ShiftBreakNoteStopId = shiftBreakNote.Id;
                    var entry = ctx.Entry(currentShift);
                    entry.Property(e => e.ShiftBreakNoteStopId).IsModified = true;
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

                try
                {
                    ShiftBreakNote shiftBreak = new ShiftBreakNote();
                    ctx.NoteSet.Add(startBreakNote);
                    ctx.SaveChanges();

                    Break newBreak = new Break();
                    newBreak.ShiftId = shiftId;
                    ctx.Breaks.Add(newBreak);
                    ctx.SaveChanges();

                    shiftBreak.NoteId = startBreakNote.Id;
                    shiftBreak.StandAloneNote = false;
                    shiftBreak.BreakShiftId = newBreak.Id;
                    ctx.ShiftBreakSet.Add(shiftBreak);
                    ctx.SaveChanges();

                    newBreak.ShiftBreakNoteStartId = shiftBreak.Id;
                    var entry = ctx.Entry(newBreak);
                    entry.Property(e => e.ShiftBreakNoteStartId).IsModified = true;
                    ctx.SaveChanges();
                    return Tuple.Create(newBreak.Id, "Success");
                }
                catch(Exception ex)
                {
                    return Tuple.Create(-2, ex.Message);
                }

            }
        }
    }
}
