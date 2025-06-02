using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ProjectTimeApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [MinLength(1)]
        public string Email { get; set; } = default!;

        [Required]
        [MinLength(1)]
        public string PasswordDigest { get; set; } = default!;

        [Required]
        public bool Active { get; set; } = false;

        public List<TimeLog> TimeLogs { get; set; } = new();
    }
}
