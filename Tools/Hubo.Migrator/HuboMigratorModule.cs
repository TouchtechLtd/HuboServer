using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Hubo.EntityFramework;

namespace Hubo.Migrator
{
    [DependsOn(typeof(HuboDataModule))]
    public class HuboMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<HuboDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}