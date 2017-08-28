﻿using Abp.Modules;
using Abp.Web.Mvc;
using Nankingcigar.Demo.Dapper;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace Nankingcigar.Demo.Web
{
    [DependsOn(
        typeof(AbpWebMvcModule),
        typeof(DemoDataModule),
        typeof(BlogDapperModule),
        typeof(DemoApplicationModule),
        typeof(DemoWebApiModule))]
    public class DemoWebModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}