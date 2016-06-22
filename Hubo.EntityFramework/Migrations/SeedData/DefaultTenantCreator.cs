using System.Linq;
using Hubo.EntityFramework;
using Hubo.MultiTenancy;

namespace Hubo.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly HuboDbContext _context;

        public DefaultTenantCreator(HuboDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == "Default");
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = "Default", Name = "Default"});
                _context.SaveChanges();
            }
        }
    }
}