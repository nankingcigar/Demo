using Dapper;
using Nankingcigar.Demo.Dapper.Extend;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nankingcigar.Demo.Core.Entity.User;

namespace Nankingcigar.Demo.Application.User
{
    internal class UserAppService : DemoAppServiceBase, IUserAppService
    {
        private readonly IDapperRepositoryExtend<Landing, long> _userLandingDapperRepositoryExtend;
        private readonly IDapperRepositoryExtend<Grid, long> _userGridDapperRepositoryExtend;

        public UserAppService(
            IDapperRepositoryExtend<Core.Entity.User.Landing, long> userLandingDapperRepositoryExtend,
            IDapperRepositoryExtend<Grid, long> userGridDapperRepositoryExtend)
        {
            _userLandingDapperRepositoryExtend = userLandingDapperRepositoryExtend;
            _userGridDapperRepositoryExtend = userGridDapperRepositoryExtend;
        }

        public virtual async Task<Landing> Get(long? userId)
        {
            return await _userLandingDapperRepositoryExtend.GetAsync(userId ?? AbpSession.UserId.Value);
        }

        public virtual async Task<IEnumerable<Grid>> GetAll()
        {
            return await _userGridDapperRepositoryExtend.GetAllAsync();
        }
    }
}