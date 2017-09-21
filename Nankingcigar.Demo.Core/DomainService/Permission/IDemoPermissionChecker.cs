using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;

namespace Nankingcigar.Demo.Core.DomainService.Permission
{
    public interface IDemoPermissionChecker : IPermissionChecker
    {
        Task<bool> IsGrantedAsync(MethodInfo methodInfo, Type type);
    }
}
