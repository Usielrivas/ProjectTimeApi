using System;

namespace ProjectTimeApi.Models
{
    public class TimeLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public DateTime Date { get; set; }
        public double Hours { get; set; }
    }
}
