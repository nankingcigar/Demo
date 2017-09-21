using Abp.Dapper;
using Abp.Modules;
using Abp.Orm;
using Abp.Reflection.Extensions;
using Nankingcigar.Demo.Dapper.Extend;
using System.Collections.Generic;
using System.Reflection;

namespace Nankingcigar.Demo.Dapper
{
    [DependsOn(typeof(AbpDapperModule))]
    public class DemoDapperModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new List<Assembly> { typeof(DemoDapperModule).GetAssembly() });

            ISecondaryOrmRegistrar additionalOrmRegistrar = IocManager.Resolve<ISecondaryOrmRegistrar>();
            additionalOrmRegistrar.RegisterRepositories(IocManager, new DapperAutoRepositoryTypeAttribute(
                typeof(IDapperRepositoryExtension<>),
                typeof(IDapperRepositoryExtension<,>),
                typeof(DapperRepositoryBaseExtension<,>),
                typeof(DapperRepositoryBaseExtension<,,>)
            ));
        }
    }
}