using System;

namespace Nankingcigar.Demo.Application.User.DTO
{
    public class User
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
    }

    public class User2 : User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}