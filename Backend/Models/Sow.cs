using Microsoft.AspNetCore.Mvc;
using System;

namespace CandidateSoW.Models
{
    public class Sow
    {
        public int? SowId { get; set; } = 0;
        public string SoName { get; set; } = "";
        public string JRCode { get; set; } = "";
        public DateTime? RequestCreationDate { get; set; } = DateTime.Now;
        public int? AccountId { get; set; } = 0;
        public int? TechnologyId { get; set; } = 0;
        public string Comments { get; set; } = "";

        public int? LocationId { get; set; } = 0;
        public int? RegionId { get; set; } = 0;
        public int? TargetOpenPositions { get; set; } = 0;
        public int? PositionsTobeClosed { get; set; } = 0;
        public int? USTPOCId { get; set; } = 0;
        public int? RecruiterId { get; set; } = 0;
        public int? USTTPMId { get; set; } = 0;
        public int? DellManagerId { get; set; } = 0;
        public int? StatusId { get; set; } = 0;
        public string Band { get; set; } = "";
        public string ProjectId { get; set; } = "";
        public string AccountManager { get; set; } = "";
        public string? ExternalResource { get; set; }
        public string? InternalResource { get; set; } 
        public string Type { get; set; } = "";
        public string TechnologyName { get; set; } = "";
        public string AccountName { get; set; } = "";
        public string Location { get; set; } = "";
        public string Region { get; set; } = "";
        public string USTPOCName { get; set; } = "";
        public string RecruiterName { get; set; } = "";
        public string USTTPMName { get; set; } = "";
        public string DellManagerName { get; set; } = "";
        public string StatusName { get; set; } = "";
        public DateTime? Onboardingdate { get; set; } = DateTime.Now;
        public string DomainName { get; set; } = "";

        //  Temp properties
        public string Domain { get; set; } = "";
        public string JR { get; set; } = "";
        //  public DateTime ? ReqCreationDate { get; set; } 
        public string Account { get; set; } = "";
        //  public string Technology { get; set; } = "";
        //public string Role { get; set; } = "";
        //  public string Location { get; set; } = "";
        //  public string Region { get; set; } = "";
        //  public int TargetOpenPositions { get; set; }
        public string USTPOC { get; set; } = "";
        public string Recruiter { get; set; } = "";
        public string USTTPM { get; set; } = "";
        public string DellManager { get; set; } = "";
        public string Status { get; set; } = "";
        public string AM { get; set; } = "";

        public bool IsOnHold { get; set; } = false;
        public string AgeingColor { get; set; } = "";
        public string JobDesc { get; set; } = "";
        public int RoleDetailsId { get; set; } = 0;
        public string RoleDetails { get; set; } = "";
        public int experienceinyears { get; set; } = 0;


    }
    public class Sowdata
    {
        public IList<Sow>? SOW { get; set; }
    }




}