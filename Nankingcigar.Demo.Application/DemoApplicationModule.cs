using Abp.Modules;
using System.Reflection;

namespace Nankingcigar.Demo
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