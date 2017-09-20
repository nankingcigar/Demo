using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Nankingcigar.Demo.Core.DomainService.Registration
{
    public interface IUserRegistrationManager : IDomainService
    {
        Task RegisterAsync(string userName, string password, string email);
    }
}
