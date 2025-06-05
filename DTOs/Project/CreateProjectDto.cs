using System.ComponentModel.DataAnnotations;

namespace ProjectTimeApi.DTOs

{
    public class CreateProjectDto
    {
        [Required]
        [MinLength(1)]
        public string Title { get; set; } = default!;
    }
}
