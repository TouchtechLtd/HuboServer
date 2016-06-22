using Hubo.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Hubo.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly HuboDbContext _context;

        public InitialHostDbBuilder(HuboDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
