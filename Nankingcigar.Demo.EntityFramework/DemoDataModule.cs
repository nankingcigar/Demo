using Abp.EntityFramework;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Nankingcigar.Demo.Core;
using Nankingcigar.Demo.Core.Extend;
using Nankingcigar.Demo.EntityFramework.EntityFramework;
using Nankingcigar.Demo.EntityFramework.EntityFramework.Repositories;
using System.Data.Entity;
using System.Reflection;

namespace Nankingcigar.Demo.EntityFramework
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(DemoCoreModule))]
    public class DemoDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<DemoDbContext>(null);
            IocManager.IocContainer.Register(Component
                .For(typeof(IRepositoryExtend<,>))
                .ImplementedBy(typeof(DemoRepositoryBase<,>))
                .LifestyleTransient());
            IocManager.IocContainer.Register(Component
                .For(typeof(IRepositoryExtend<>))
                .ImplementedBy(typeof(DemoRepositoryBase<>))
                .LifestyleTransient());
        }
    }
}