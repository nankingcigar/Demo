using Dapper;
using Nankingcigar.Demo.Dapper.Extend;
using System.Threading.Tasks;
using Abp.Application.Services;
using Nankingcigar.Demo.Application.User.DTO;
using System;
using System.Collections.Generic;

namespace Nankingcigar.Demo.Application.User
{
    internal class UserAppService : DemoAppServiceBase, IUserAppService
    {
        private readonly IDapperRepositoryExtend<Core.Entity.User, long> _userDapperRepositoryExtend;

        public UserAppService(IDapperRepositoryExtend<Core.Entity.User, long> userDapperRepositoryExtend)
        {
            _userDapperRepositoryExtend = userDapperRepositoryExtend;
        }

        public virtual async Task<DTO.User> Get(long? userId)
        {
            string sql = $"select UserName, DisplayName from [User] where Id = { userId ?? AbpSession.UserId}";
            return await _userDapperRepositoryExtend.GetConnection().QueryFirstAsync<DTO.User>(
                sql,
                null,
                _userDapperRepositoryExtend.GetTransaction()
            );
        }

        public virtual async Task<IEnumerable<DTO.User2>> GetAll()
        {
            string sql = $"select Id, UserName, DisplayName, Email, LastLoginTime from [User]";
            return await _userDapperRepositoryExtend.GetConnection().QueryAsync<DTO.User2>(
                sql, 
                null, 
                _userDapperRepositoryExtend.GetTransaction()
           );
        }
    }
}