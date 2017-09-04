using System.ComponentModel.DataAnnotations;

namespace Nankingcigar.Demo.Account.DTO
{
    public class RegisterInput
    {
        [Required]
        [StringLength(50)]
        public virtual string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public virtual string Password { get; set; }

        [Required]
        [StringLength(100)]
        public virtual string Email { get; set; }
    }
}