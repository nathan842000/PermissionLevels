using PermissionLevels.DTOs;

namespace PermissionLevels.Repositories.Interfaces
{
    public interface IModuleRepository
    {
        List<Module> GetAll();
    }
}
