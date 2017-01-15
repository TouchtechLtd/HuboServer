using Hubo.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.EntityFramework
{
    public class VehicleRepository : IVehicleRepository
    {


        public int RegisterVehicle(Vehicle vehicle)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                 
                //ctx.VehiclesSet.Add(testVehicle);

                try
                {
                    int result = 0;
                    // check rego number doesn't already exist
                    if (ctx.VehiclesSet.Any(o => o.RegistrationNo == vehicle.RegistrationNo))
                    {
                        // Match!
                        result = -1;
                    }
                    else
                    {
                        ctx.Entry(vehicle).State = System.Data.Entity.EntityState.Added;
                        result = ctx.SaveChanges();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    string x = ex.Message;

                    return 0;
                }

            }
        }
    }
}
