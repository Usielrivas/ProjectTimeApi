using System.Collections.Generic;

namespace ProjectTimeApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<TimeLog> TimeLogs { get; set; } = new();
    }
}
