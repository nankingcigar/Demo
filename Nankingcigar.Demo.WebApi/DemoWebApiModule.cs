using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using System.Reflection;

namespace Nankingcigar.Demo
{
    [DependsOn(typeof(AbpWebApiModule), typeof(DemoApplicationModule))]
    public class DemoWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(DemoApplicationModule).Assembly, "app")
                .WithConventionalVerbs()
                .Build();
        }
    }
}