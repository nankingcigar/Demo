using System.ComponentModel.DataAnnotations;

namespace Nankingcigar.Demo.WebApi.DTO
{
    public class LoginInput
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}