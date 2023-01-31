using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using PermissionLevels.DTOs;
using PermissionLevels.Repositories.Interfaces;

namespace PermissionLevels.Repositories
{
    public class PermissionTypeRepository : IPermissionTypeRepository
    {
        private readonly Configuration _configuration;
        private readonly ILogger<PermissionTypeRepository> _logger;

        public PermissionTypeRepository(Configuration configuration, ILogger<PermissionTypeRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public List<PermissionType> GetAll()
        {
            var result = new List<PermissionType>();

            try
            {
                using (var connection = new SqlConnection(_configuration.ConnectionString))
                {
                    connection.Open();
                    result = connection.Query<PermissionType>("dbo.PermissionTypes_RetrieveAll", commandType: System.Data.CommandType.StoredProcedure).ToList();
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
