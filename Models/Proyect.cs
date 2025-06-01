using System.Collections.Generic;

namespace ProjectTimeApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public List<TimeLog> TimeLogs { get; set; } = new();
    }
}
