namespace CandidateSoW.Models
{
    public class L2Model
    {
        public int L2Id { get; set; }
        public int L2Selected { get; set; } = 0;
        public int L2Rejected { get; set; } = 0;
        public int L2 { get; set; } = 0;
        public int L1Id { get; set; } = 0;
        public string Type { get; set; } = "";
        public int Onhold { get; set; } = 0;

    }
}
