using PermissionLevels.DTOs;

namespace PermissionLevels.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
    }
}
