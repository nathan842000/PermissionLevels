using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using PermissionLevels.DTOs;
using PermissionLevels.Repositories.Interfaces;

namespace PermissionLevels.Repositories
{
    public class ApplicationPermissionTypeRepository : IApplicationPermissionTypeRepository
    {
        private readonly Configuration _configuration;
        private readonly ILogger<ApplicationPermissionTypeRepository> _logger;

        public ApplicationPermissionTypeRepository(Configuration configuration, ILogger<ApplicationPermissionTypeRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public List<ApplicationPermissionType> GetAll()
        {
            var result = new List<ApplicationPermissionType>();

            try
            {
                using (var connection = new SqlConnection(_configuration.ConnectionString))
                {
                    connection.Open();
                    result = connection.Query<ApplicationPermissionType>("dbo.ApplicationPermissionTypes_RetrieveAll", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return result;
        }
    }
}
