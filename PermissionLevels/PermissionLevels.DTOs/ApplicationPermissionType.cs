namespace PermissionLevels.DTOs
{
    public class ApplicationPermissionType
    {
        public int ApplicationPermissionTypeID { get; set; }
        public int ApplicationID { get; set; }
        public int PermissionTypeID { get; set; }
        public string? ApplicationName { get; set; }
        public string? PermissionType { get; set; }
    }
}
