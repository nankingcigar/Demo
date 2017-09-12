using System.Reflection;
using Abp.Modules;

namespace Nankingcigar.Demo.Core
{
    public class DemoCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
