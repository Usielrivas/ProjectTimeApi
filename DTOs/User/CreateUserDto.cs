using System.ComponentModel.DataAnnotations;

namespace ProjectTimeApi.DTOs

{
    public class CreateUserDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
