using System.Reflection;
using Abp.Modules;
using Nankingcigar.Demo.Core;

namespace Nankingcigar.Demo.Event
{
    [DependsOn(typeof(DemoCoreModule))]
    public class DemoEventModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}