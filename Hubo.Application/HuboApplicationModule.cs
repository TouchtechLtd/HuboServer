using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Hubo
{
    [DependsOn(typeof(HuboCoreModule), typeof(AbpAutoMapperModule))]
    public class HuboApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
