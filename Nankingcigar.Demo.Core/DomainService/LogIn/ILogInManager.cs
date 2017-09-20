using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Nankingcigar.Demo.Core.DomainService.LogIn
{
    public interface ILogInManager : IDomainService
    {
        Task<ClaimsIdentity> LoginAsync(string userNameOrEmailAddress, string plainPassword);
    }
}
