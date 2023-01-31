namespace PermissionLevels.DTOs
{
    public class User
    {
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public int GroupID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }
        public string? GroupName { get; set; }
    }
}
