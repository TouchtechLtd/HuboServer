using Hubo.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Hubo.EntityFramework
{
    public class VehicleRepository : IVehicleRepository
    {


        public Tuple<int,string> RegisterVehicle(Vehicle vehicle)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    int result = 0;
                    // check rego number doesn't already exist
                    if (ctx.VehicleSet.Any(o => o.RegistrationNo == vehicle.RegistrationNo))
                    {
                        // Match!
                        return Tuple.Create(-1, "Registration Number already exists");
                    }

                    ctx.Entry(vehicle).State = System.Data.Entity.EntityState.Added;
                    result = ctx.SaveChanges();

                    return Tuple.Create(vehicle.Id, "Success");
                }
                catch (Exception ex)
                {
                    return Tuple.Create(-1, ex.Message);
                }

            }
        }

        public Tuple<List<Vehicle>, string, int> GetVehiclesByDriver(int driverId)
        {
            List<Vehicle> listOfVehicles = new List<Vehicle>();
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    if(!ctx.DriverSet.Any(d => d.Id == driverId))
                    {
                        return Tuple.Create(listOfVehicles, "Company not found for corresponding ID : " + driverId.ToString(), -1);
                    }                   

                    listOfVehicles                       = (from vehicle in ctx.VehicleSet
                                                           join company in ctx.CompanySet on vehicle.CompanyId equals company.Id
                                                           join driveCompany in ctx.DriverCompanySet on company.Id equals driveCompany.CompanyId
                                                           where driveCompany.DriverId == driverId
                                                           select vehicle).ToList<Vehicle>();



                    return Tuple.Create(listOfVehicles, "success", 1);

                }
                catch(Exception ex)
                {
                    return Tuple.Create(listOfVehicles, ex.Message, -1);
                }
            }
        }

        public Tuple<List<Vehicle>, string, int> GetVehicles(List<long> listCompanyIds)
        {
            List<Vehicle> listOfVehicles = new List<Vehicle>();
            using (HuboDbContext ctx = new HuboDbContext())
            {
                try
                {
                    listOfVehicles = ctx.VehicleSet.Where(t => listCompanyIds.Contains(t.CompanyId)).ToList<Vehicle>();
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
