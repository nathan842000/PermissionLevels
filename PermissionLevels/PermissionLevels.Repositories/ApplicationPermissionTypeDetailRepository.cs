using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using PermissionLevels.DTOs;
using PermissionLevels.Repositories.Interfaces;

namespace PermissionLevels.Repositories
{
    public class ApplicationPermissionTypeDetailRepository : IApplicationPermissionTypeDetailRepository
    {
        private readonly Configuration _configuration;
        private readonly ILogger<ApplicationPermissionTypeDetailRepository> _logger;

        public ApplicationPermissionTypeDetailRepository(Configuration configuration, ILogger<ApplicationPermissionTypeDetailRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public List<ApplicationPermissionTypeDetail> GetByApplicationPermissionTypeID(int applicationPermissionTypeID)
        {
            var result = new List<ApplicationPermissionTypeDetail>();

            try
            {
                using (var connection = new SqlConnection(_configuration.ConnectionString))
                {
                    connection.Open();

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("applicationPermissionTypeID", applicationPermissionTypeID);

                    result = connection.Query<ApplicationPermissionTypeDetail>("dbo.ApplicationPermissionTypeDetails_RetrieveAll", parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
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
