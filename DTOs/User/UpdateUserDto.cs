using System.ComponentModel.DataAnnotations;
namespace ProjectTimeApi.DTOs

{
    public class UpdateUserDto
    {
        [Required]
        [EmailAddress]
        [MinLength(1)]
        public string? Email { get; set; } = default!;

        [Required]
        [MinLength(8)]
        public string? Password { get; set; } = default!;

        [Required]
        [MinLength(8)]
        public string? PasswordComfirm { get; set; } = default!;

        public bool? Active { get; set; }
    }
}
