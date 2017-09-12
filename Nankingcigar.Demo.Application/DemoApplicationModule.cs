using Abp.Modules;
using Nankingcigar.Demo.Core;
using System.Reflection;

namespace Nankingcigar.Demo.Application
{
    [DependsOn(typeof(DemoCoreModule))]
    public class DemoApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}