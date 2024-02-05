namespace CandidateSoW.Models
{
    public class LoginModel
    {
        public string LoginName { get; set; } = "";
        public string EmailId { get; set; } = "";
        public string RoleName { get; set; } = "";
        public string ScreenNames { get; set; } = "";
        public string TabNames { get; set; } = "";

        public string Status { get; set; } = "";
        public string PermissionName { get; set; } = "";
        public int FailureAttempts { get; set; } = 0;
        public bool Islock { get; set; }=false;
        public bool IsFirstLogin { get; set; } = false;
        public string Image { get; set; } = "";
        public string MobileNo { get; set; } = "";

    }
}
