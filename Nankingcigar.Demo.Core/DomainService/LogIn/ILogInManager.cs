using Abp.Domain.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Core.DomainService.LogIn
{
    public interface ILogInManager : IDomainService
    {
        Task<ClaimsIdentity> LoginAsync(string userNameOrEmailAddress, string plainPassword);
    }
}