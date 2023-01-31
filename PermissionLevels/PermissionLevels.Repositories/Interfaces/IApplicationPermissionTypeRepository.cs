using PermissionLevels.DTOs;

namespace PermissionLevels.Repositories.Interfaces
{
    public interface IApplicationPermissionTypeRepository
    {
        List<ApplicationPermissionType> GetAll();
    }
}
