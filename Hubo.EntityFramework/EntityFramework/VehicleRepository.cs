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
                    if (ctx.VehicleSet.Any(o => o.RegistrationNo == vehicle.RegistrationNo))
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

        public Tuple<List<Vehicle>, string, int> GetVehicles(int companyId)
        {
            List<Vehicle> listOfVehicles = new List<Vehicle>();
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    if (!ctx.CompanySet.Any(c => c.Id == companyId))
                    {                        
                        return Tuple.Create(listOfVehicles, "Company not found for corresponding CompanyID", -1);
                    }

                    IQueryable<Vehicle> listVehicleQuery;
                    listVehicleQuery = from b in ctx.VehicleSet
                                       where b.CompanyId.Equals(companyId)
                                       select b;
                    listOfVehicles = listVehicleQuery.ToList<Vehicle>();

                    //if(listOfVehicles.Count == 0)
                    //{
                    //    return Tuple.Create(listOfVehicles, "No Vehicles found for company", -1);
                    //}

                    return Tuple.Create(listOfVehicles, "Success", 1);
                }
                catch (Exception ex)
                {
                    return Tuple.Create(listOfVehicles, ex.Message, -1);
                }
            }
        }
    }
}
