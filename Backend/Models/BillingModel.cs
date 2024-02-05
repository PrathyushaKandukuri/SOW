namespace CandidateSoW.Models
{
    public class BillingModel
    {
        public int BillingId { get; set; } = 0;
        public DateTime ResourceStartDate { get; set; }=DateTime.Now;
        public DateTime ResourceEndDate { get; set; }= DateTime.Now;
        public string Domain { get; set; } = "";
        public string Currency { get; set; } = "";
        public double BillRate { get; set; } = 0;
        public double Hours { get; set; } = 0;
        public double TotalBilledhrs { get; set; } = 0;
        public int SowId { get; set; } = 1;
        public int CandidateId { get; set; } = 0;
        public string Type { get; set; } = "";
        public int EmployeeId { get; set; } = 0;
        public int CustomerTypeId { get; set; } = 0;
        public int ProjectTypeId { get; set; } = 0;
        public bool Billable { get; set; } = false;
        public string ClientProjectRole { get; set; } = "";
        public string ClientProjectRoleDesc { get; set; } = "";
        public string AliasName { get; set; } = "";
        public double AllocationPercentage { get; set; } = 0;
        public string Comments { get; set; } = "";
        public int ProjectManagerTypeId { get; set; } = 0;
        public int ContractCategoryId { get; set; } = 0;
        public int JobCodeId { get; set; } = 0;
        public int FrequencyId { get; set; } = 0;
        public int BussinessUnitId { get; set; } = 0;
        public int DepartmentTypeId { get; set; } = 0;

        public string? CandidateName { get; set; }
        public string? CandidateUid { get; set; }
        public string ContractCategory { get; set; } = "";

        public string CustomerId { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public int DepartmentId { get; set; } = 0;

        public string DepartmentDescription { get; set; } = "";

        public string EmployeeType { get; set; } = "";
        public string Frequency { get; set; } = "";

        public string JobCode { get; set; } = "";
        public string JobDescription { get; set; } = "";
        public string ProjectManagerId { get; set; } = string.Empty;
        public string ProjectManagerName { get; set; } = string.Empty;
        public DateTime ProjectStartDate { get; set; } = DateTime.Now;
        public DateTime ProjectEndDate { get; set; } = DateTime.Now;
        public string ProjectId { get; set; } = "";
        public string ProjectDescription { get; set; } = "";
        public DateTime JoiningDate { get; set; }=DateTime.Now;
        public string BussinessUnit { get; set; } = "";
        public string BussinessUnitDescription { get; set; } = "";

        public int LocationTypeId { get; set; } = 0;
        public string LocationId { get; set; } = "";
        public string LocationDescription { get; set; } = "";
        public int RegionId { get; set; } = 0;
        public string Region { get; set; } = "";
        public int USTTPMId { get; set; } = 0;
        public string USTTPMName { get; set; } = "";
        public string USTTPMUID { get; set; } = "";
        public DateTime TerminationDate { get; set; } = DateTime.Now;
        public int OBU { get; set; } = 0;
        public string OBUDescription { get; set; } = "";



    }
    public class BillingData
    {
        public IList<BillingModel>? Billing { get; set; }
    }
}
