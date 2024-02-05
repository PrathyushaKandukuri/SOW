namespace CandidateSoW.Models
{
    public class ScreeningModel
    {
        public int ScreeningId { get; set; }
        public int ScreeningSelected { get; set; } = 0;
        public int ScreeningRejected { get; set; } = 0;
        public int SowId { get; set; } = 0;
        public string CandidateId { get; set; } = "";
        public string Type { get; set; } = "";
        public int Screening { get; set; } = 0;
        public string CandidateName { get; set; } = "";
        public string CandidateUID { get; set; } = "";
        public string SelectedCandidateIds { get; set; } = "";
        public string RejectedCandidateIds { get; set; } = "";
        public bool IsSelected { get; set; } = false;
        public int SOW_CandidateId { get; set; } = 0;
        public DateTime? MappingDate { get; set; }

    }
}
