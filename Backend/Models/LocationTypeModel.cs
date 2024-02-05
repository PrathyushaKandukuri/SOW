namespace CandidateSoW.Models
{
    public class LocationTypeModel
    {
        public int LocationTypeId { get; set; } = 0;
        public string LocationId { get; set; } = "";
        public string LocationDescription { get; set; } = "";
        public int RegionId { get; set; } = 0;
        public string Type { get; set; } = "";
    }
}
