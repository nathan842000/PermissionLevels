using PermissionLevels.DTOs;

namespace PermissionLevels.Repositories.Interfaces
{
    public interface IApplicationRepository
    {
        List<Application> GetAll();
    }
}
