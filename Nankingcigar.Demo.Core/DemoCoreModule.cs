using Abp.Authorization;
using Abp.Dependency;
using Abp.Modules;
using Nankingcigar.Demo.Core.DomainService.Authorization;
using System.Reflection;

namespace Nankingcigar.Demo.Core
{
    public class DemoCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<IAuthorizationHelper, DemoAuthorizationHelper>(DependencyLifeStyle.Transient);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}