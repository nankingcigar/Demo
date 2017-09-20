using Abp.Application.Services;
using Abp.Authorization;

namespace Nankingcigar.Demo.Application
{
    /// <inheritdoc />
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    [AbpAuthorize]
    internal abstract class DemoAppServiceBase : ApplicationService
    {
    }
}