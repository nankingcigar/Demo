using Abp.Application.Services;
using Abp.Authorization;

namespace Nankingcigar.Demo
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    [AbpAuthorize]
    internal abstract class DemoAppServiceBase : ApplicationService
    {
    }
}