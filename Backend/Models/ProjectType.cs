namespace CandidateSoW.Models
{
    public class ProjectType
    {
        public int ProjectTypeId { get; set; }
        public string ProjectId { get; set; } = "";
        public string ProjectDescription { get; set; } = "";
        public DateTime ProjectStartDate { get; set; } = DateTime.Now;
        public DateTime ProjectEndDate { get; set; } = DateTime.Now;
        public string Type { get; set; } = "";
    }
}
