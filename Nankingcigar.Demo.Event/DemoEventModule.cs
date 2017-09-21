using Abp.Modules;
using Nankingcigar.Demo.Core;
using System.Reflection;

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