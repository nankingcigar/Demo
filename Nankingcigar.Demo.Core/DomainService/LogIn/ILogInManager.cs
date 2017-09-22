using Abp.Domain.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Core.DomainService.Login
{
    public interface ILoginManager : IDomainService
    {
        Task<ClaimsIdentity> LoginAsync(string userNameOrEmailAddress, string plainPassword);
    }
}