using Castle.Core.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nankingcigar.Demo.Account.DTO
{
    public class RegisterInput : IValidatableObject
    {
        [Required]
        [StringLength(50)]
        public virtual string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public virtual string Password { get; set; }

        [StringLength(50)]
        public virtual string DisplayName { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UserName.IsNullOrEmpty() || Password.IsNullOrEmpty())
                yield return new ValidationResult("Username & Password both can't be empty !");
        }
    }
}