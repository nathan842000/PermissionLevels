namespace PermissionLevels.DTOs
{
    public class ApplicationPermissionTypeDetail
    {
        public int ApplicationPermissionTypeDetailID { get; set; }
        public int ApplicationPermissionTypeID { get; set; }
        public int CompanyIDGroupIDUserID { get; set; }
        public string? ApplicationName { get; set; }
        public string? PermissionType { get; set; }
        public string? CompanyNameOrGroupNameOrUserName { get; set; }
    }
}
