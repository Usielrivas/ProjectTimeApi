using System.ComponentModel.DataAnnotations;

namespace ProjectTimeApi.DTOs

{
    public class CreateUserDto : IValidatableObject
    {
        [Required]
        [EmailAddress]
        [MinLength(1)]
        public string Email { get; set; } = default!;

        [Required]
        [MinLength(8)]
        public string Password { get; set; } = default!;

        [Required]
        [MinLength(8)]
        public string PasswordComfirm { get; set; } = default!;

        public bool Active { get; set; } = false;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password != PasswordComfirm)
            {
                yield return new ValidationResult("Passwords do not match", new[] { nameof(PasswordComfirm) });
            }
        }
    }
}
