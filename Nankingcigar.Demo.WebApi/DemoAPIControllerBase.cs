using Abp.Dependency;
using Abp.Web.Models;
using Abp.WebApi.Authorization;
using Abp.WebApi.Controllers;

namespace Nankingcigar.Demo.WebApi
{
    [AbpApiAuthorize]
    [WrapResult]
    public abstract class DemoApiControllerBase : AbpApiController, ITransientDependency
    {
    }
}