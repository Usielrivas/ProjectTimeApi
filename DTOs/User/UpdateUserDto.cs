using System.ComponentModel.DataAnnotations;
namespace ProjectTimeApi.DTOs

{
    public class UpdateUserDto : IValidatableObject
    {
        [EmailAddress]
        [MinLength(1)]
        public string? Email { get; set; }

        [MinLength(8)]
        public string? Password { get; set; }

        [MinLength(8)]
        public string? PasswordComfirm { get; set; }

        public bool? Active { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password != PasswordComfirm)
            {
                yield return new ValidationResult("Passwords do not match", new[] { nameof(PasswordComfirm) });
            }
        }
    }
}
