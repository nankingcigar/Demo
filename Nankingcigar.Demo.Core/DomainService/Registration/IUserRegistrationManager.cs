using Abp.Domain.Services;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Core.DomainService.Registration
{
    public interface IUserRegistrationManager : IDomainService
    {
        Task RegisterAsync(string userName, string password, string email);
    }
}