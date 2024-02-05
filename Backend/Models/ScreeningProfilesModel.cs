using System.Reflection.PortableExecutable;

namespace CandidateSoW.Models
{
    public class ScreeningProfilesModel
    {
        public int SowId { get; set; }
        public string ProjectId { get; set; } = "";
        public string JRCode { get; set; } = "";
        public int StatusId { get; set; } = 0;
        public string StatusName { get; set; } = "";
        public int count { get; set; } = 0;
        public string Type { get; set; } = "";
        public int ScreeningSelected { get; set; } = 0;
        public int Screeningrejceted { get; set; } = 0;
        public int L1selected { get; set; } = 0;
        public int L1rejected { get; set; } = 0;
        public int L2selected { get; set; } = 0;
        public int L2rejceted { get; set; } = 0;
        public int OfferAccepted { get; set; } = 0;
        public int OfferRejected { get; set; } = 0;
        public int TotalProfilesTagged { get; set; } = 0;
        public int TotalProfilesRejected { get; set; } = 0;
        public int ScreeningONhold { get; set; } = 0;
        public int L1OnHold { get; set; } = 0;
        public int L2OnHold { get; set; } = 0;
        public int InProgress { get; set; } = 0;
        public DateTime? StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}
