using PermissionLevels.DTOs;

namespace PermissionLevels.Repositories.Interfaces
{
    public interface IApplicationPermissionTypeDetailRepository
    {
        List<ApplicationPermissionTypeDetail> GetByApplicationPermissionTypeID(int applicationPermissionTypeID);
    }
}
