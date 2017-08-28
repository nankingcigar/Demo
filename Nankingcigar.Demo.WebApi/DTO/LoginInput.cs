using System.ComponentModel.DataAnnotations;

namespace Nankingcigar.Demo.WebApi.DTO
{
    public class LoginInput
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}