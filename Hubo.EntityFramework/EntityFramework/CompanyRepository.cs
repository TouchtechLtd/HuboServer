using Hubo.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.EntityFramework
{
    public class CompanyRepository : ICompanyRepository
    {
        public Tuple<List<Company>, string, int> GetCompanyList(int driverId)
        {
            List<Company> listOfCompanies = new List<Company>();
            using (HuboDbContext ctx = new HuboDbContext())
            {

                try
                {
                    if (!ctx.DriverSet.Any(d => d.Id == driverId))
                    {
                        return Tuple.Create(listOfCompanies, "No Driver found with corresponding ID = " + driverId.ToString(), -1);
                    }

                    List<DriverCompany> driverCompanies = (from b in ctx.DriverCompanySet
                                                           where b.DriverId.Equals(driverId)
                                                           select b).ToList<DriverCompany>();

                    foreach (DriverCompany driverCompany in driverCompanies)
                    {
                        Company tempCompany = ctx.CompanySet.Single<Company>(c => c.Id == driverCompany.CompanyId);
                        listOfCompanies.Add(tempCompany);
                    }

                    if (listOfCompanies.Count == 0)
                    {
                        return Tuple.Create(listOfCompanies, "No Companies found for Driver ID = " + driverId.ToString(), -1);
                    }

                    return Tuple.Create(listOfCompanies, "Success", 1);
                }
                catch(Exception ex)
                {
                    return Tuple.Create(listOfCompanies, ex.Message, -1);
                }


            }
        }
    }
}
