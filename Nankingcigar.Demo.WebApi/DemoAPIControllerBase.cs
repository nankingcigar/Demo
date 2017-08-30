using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Events.Bus;
using Abp.Events.Bus.Exceptions;
using Abp.Logging;
using Abp.Runtime.Session;
using Abp.Runtime.Validation;
using Abp.Web.Models;
using Abp.WebApi.Authorization;
using Abp.WebApi.Configuration;
using Abp.WebApi.Controllers;
using Abp.WebApi.ExceptionHandling;
using Castle.Core.Logging;

namespace Nankingcigar.Demo.WebApi
{
    [AbpApiAuthorize]
    [WrapResult]
    public abstract class DemoApiControllerBase : AbpApiController, ITransientDependency
    {
    }
}