using Hubo.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
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
                ctx.VehiclesSet.Add(vehicle);


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
