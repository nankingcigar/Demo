using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Castle.Facilities.Logging;
using System;
using System.Web.Http;
using Abp.Json;
using Nankingcigar.Demo.Web.Models;
using Newtonsoft.Json;

namespace Nankingcigar.Demo.Web
{
    public class MvcApplication : AbpWebApplication<DemoWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig(Server.MapPath("log4net.config"))
            );

            base.Application_Start(sender, e);
            GlobalConfiguration.Configure((config) =>
            {
                int index = 0;
                foreach (var converter in config.Formatters.JsonFormatter.SerializerSettings.Converters)
                {
                    var timeConverter = converter as AbpDateTimeConverter;
                    if (timeConverter != null)
                    {
                        break;
                    }
                    index++;
                }
                config.Formatters.JsonFormatter.SerializerSettings.Converters[index] = new DemoDateTimeConverter();
            });
        }
    }
}