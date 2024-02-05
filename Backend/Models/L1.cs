namespace CandidateSoW.Models
{
    public class L1
    {
        public int L1Id { get; set; }
        public int L1Selected { get; set; } = 0;
        public int L1Rejected { get; set; } = 0;
        public int L1Total { get; set; } = 0;
        public int ScreeningId { get; set; } = 0;
        public int Screening { get; set; } = 0;
        public string Type { get; set; } = "";
        public int OnHold { get; set; } = 0;
    }
}
