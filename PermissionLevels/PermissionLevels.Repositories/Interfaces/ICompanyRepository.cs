using PermissionLevels.DTOs;

namespace PermissionLevels.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        List<Company> GetAll();
    }
}
