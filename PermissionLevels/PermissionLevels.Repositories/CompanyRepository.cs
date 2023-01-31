using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using PermissionLevels.DTOs;
using PermissionLevels.Repositories.Interfaces;

namespace PermissionLevels.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly Configuration _configuration;
        private readonly ILogger<CompanyRepository> _logger;

        public CompanyRepository(Configuration configuration, ILogger<CompanyRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public List<Company> GetAll()
        {
            var result = new List<Company>();

            try
            {
                using (var connection = new SqlConnection(_configuration.ConnectionString))
                {
                    connection.Open();
                    result = connection.Query<Company>("dbo.Companies_RetrieveAll", commandType: System.Data.CommandType.StoredProcedure).ToList();
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
