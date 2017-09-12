using System.Threading.Tasks;
using Dapper;
using Nankingcigar.Demo.Dapper.Extend;

namespace Nankingcigar.Demo.Application.User
{
    internal class UserAppService : DemoAppServiceBase, IUserAppService
    {
        private readonly IDapperRepositoryExtend<Core.Entity.User, long> _userDapperRepositoryExtend;

        public UserAppService(IDapperRepositoryExtend<Core.Entity.User, long> userDapperRepositoryExtend)
        {
            _userDapperRepositoryExtend = userDapperRepositoryExtend;
        }

        public virtual async Task<Application.User.DTO.User> GetCurrentUser()
        {
            string sql = $"select UserName, DisplayName from [User] where Id = {AbpSession.UserId}";
            return await _userDapperRepositoryExtend.GetConnection().QueryFirstAsync<Application.User.DTO.User>(sql, null, _userDapperRepositoryExtend.GetTransaction());
        }
    }
}