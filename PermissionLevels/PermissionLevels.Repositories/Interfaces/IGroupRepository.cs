using PermissionLevels.DTOs;

namespace PermissionLevels.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        List<Group> GetAll();
    }
}
