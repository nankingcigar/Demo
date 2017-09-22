using Abp.Authorization;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.Core.DomainService.Permission
{
    public interface IDemoPermissionChecker : IPermissionChecker
    {
        Task<bool> IsGrantedAsync(MethodInfo methodInfo, Type type);
    }
}