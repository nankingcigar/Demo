using Dapper;
using Nankingcigar.Demo.Dapper.Extend;
using Nankingcigar.Demo.User.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nankingcigar.Demo.User
{
    internal class UserAppService : DemoAppServiceBase, IUserAppService
    {
        private readonly IDapperRepositoryExtend<Core.Entity.User, long> _userDapperRepositoryExtend;

        public UserAppService(IDapperRepositoryExtend<Core.Entity.User, long> userDapperRepositoryExtend)
        {
            _userDapperRepositoryExtend = userDapperRepositoryExtend;
        }

        public virtual async Task<DTO.User> GetCurrentUser()
        {
            string sql = $"select UserName, DisplayName from [User] where Id = {AbpSession.UserId}";
            return await _userDapperRepositoryExtend.GetConnection().QueryFirstAsync<DTO.User>(sql, null, _userDapperRepositoryExtend.GetTransaction());
        }
    }
}