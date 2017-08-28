using Abp.Modules;
using System.Reflection;

namespace Nankingcigar.Demo
{
    public class DemoCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}