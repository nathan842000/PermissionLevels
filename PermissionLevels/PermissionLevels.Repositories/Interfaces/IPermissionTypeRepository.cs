using PermissionLevels.DTOs;

namespace PermissionLevels.Repositories.Interfaces
{
    public interface IPermissionTypeRepository
    {
        List<PermissionType> GetAll();
    }
}
