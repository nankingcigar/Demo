using Abp.Modules;
using System.Reflection;
using System.Threading;
using Abp.Authorization;
using Abp.Dependency;
using Castle.MicroKernel.Registration;
using Nankingcigar.Demo.Core.DomainService.Authorization;
using Nankingcigar.Demo.Core.Extension.Repository;

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