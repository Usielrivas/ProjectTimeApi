using System.ComponentModel.DataAnnotations;

namespace ProjectTimeApi.DTOs

{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        [MinLength(3)]
        public string Email { get; set; } = default!;

        [Required]
        [MinLength(8)]
        public string Password { get; set; } = default!;
    }

    public class AuthOkDto
    {
        public required string Key { get; set; }
    }
}
