using Abp.WebApi.Authorization;
using Abp.WebApi.Controllers;

namespace Nankingcigar.Demo.WebApi
{
    [AbpApiAuthorize]
    public abstract class DemoApiControllerBase : AbpApiController
    {
    }
}