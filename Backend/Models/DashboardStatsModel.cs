namespace CandidateSoW.Models
{
    public class DashboardStatsModel
    {
        public string? Category { get; set; }
        public string? Name { get; set; }
        public int Count { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;

    }
}