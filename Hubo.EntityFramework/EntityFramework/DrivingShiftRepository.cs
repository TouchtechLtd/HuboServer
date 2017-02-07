﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.EntityFramework
{
    public class DrivingShiftRepository
    {
        public Tuple<List<DrivingShift>, string, int> GetDrivingShifts(int shiftId)
        {
            List<DrivingShift> listOfDrivingShifts = new List<DrivingShift>();
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    if (!ctx.WorkShiftSet.Any(s => s.Id == shiftId))
                    {
                        return Tuple.Create(listOfDrivingShifts, "No Shift exists with the ID = " + shiftId, -1);
                    }

                    listOfDrivingShifts = (from b in ctx.DrivingShiftSet
                                           where b.ShiftId == shiftId
                                           select b).ToList<DrivingShift>();

                    return Tuple.Create(listOfDrivingShifts, "Success", 1);

                }
                catch (Exception ex)
                {
                    return Tuple.Create(listOfDrivingShifts, ex.Message, -1);
                }
            }
        }

        public Tuple<int, string> StartDriving(DrivingShift shift)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    if(!ctx.WorkShiftSet.Any(s => s.Id == shift.ShiftId))
                    {
                        return Tuple.Create(-1, "No Shift exists with the ID = " + shift.ShiftId);
                    }
                    if(!ctx.VehicleSet.Any(v => v.Id == shift.VehicleId))
                    {
                        return Tuple.Create(-1, "No Vehicle exists with the ID = " + shift.VehicleId);
                    }

                    shift.State = true;
                    ctx.DrivingShiftSet.Add(shift);
                    ctx.SaveChanges();
                    return Tuple.Create(shift.Id, "Success");
                }
                catch(Exception ex)
                {
                    return Tuple.Create(-1, ex.Message);
                }
            }
        }

        public Tuple<int, string> StopDriving(int drivingShiftId)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    DrivingShift shift = ctx.DrivingShiftSet.Single<DrivingShift>(s => s.Id == drivingShiftId);
                    if(shift.State == false)
                    {
                        return Tuple.Create(-1, "Driving shift has already ended");
                    }
                    shift.State = false;
                    ctx.Entry(shift).State = EntityState.Modified;
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

        public Tuple<int, string> InsertGeoData(GeoData geoData)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    if(!ctx.DrivingShiftSet.Any(s => s.Id == geoData.DrivingShiftId))
                    {
                        return Tuple.Create(-1, "No Driving Shift exists with ID = " + geoData.DrivingShiftId);
                    }

                    ctx.GeoDataSet.Add(geoData);
                    ctx.SaveChanges();
                    return Tuple.Create(geoData.Id, "Success");
                }
                catch(Exception ex)
                {
                    return Tuple.Create(-1, ex.Message);
                }
            }
        }

    }
}