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
        public List<Company> GetCompanyList(Driver driver)
        {
            using (HuboDbContext ctx = new HuboDbContext())
            {
                List<Company> listOfCompanies = new List<Company>();

                try
                {
                    //Get middle man from driver id to find all companies associated with driver
                    IQueryable<DriverCompany> driveCompanies;

                    driveCompanies= from b in ctx.DriverCompaniesSet
                                          where b.DriverId.Equals(driver.Id)
                                          select b;
                                        
                    foreach (DriverCompany driverCompany in driveCompanies.ToList<DriverCompany>())
                    {
                        IQueryable<Company> tempCompany;
                        tempCompany = from b in ctx.CompaniesSet
                                  where b.Id.Equals(driverCompany.CompanyId)
                                  select b;
                        foreach(Company company in tempCompany.ToList<Company>())
                        {
                            listOfCompanies.Add(company);
                        }
                    }
                    
                    return listOfCompanies;
                }
                catch (Exception ex)
                {
                    string x = ex.Message;

                    return listOfCompanies;
                }
            }
        }
    }
}
