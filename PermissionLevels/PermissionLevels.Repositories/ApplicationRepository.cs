using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using PermissionLevels.DTOs;
using PermissionLevels.Repositories.Interfaces;

namespace PermissionLevels.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly Configuration _configuration;
        private readonly ILogger<ApplicationRepository> _logger;

        public ApplicationRepository(Configuration configuration, ILogger<ApplicationRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public List<Application> GetAll()
        {
            var result = new List<Application>();

            try
            {
                using (var connection = new SqlConnection(_configuration.ConnectionString))
                {
                    connection.Open();
                    result = connection.Query<Application>("dbo.Applications_RetrieveAll", commandType: System.Data.CommandType.StoredProcedure).ToList();
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
