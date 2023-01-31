using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using PermissionLevels.DTOs;
using PermissionLevels.Repositories.Interfaces;

namespace PermissionLevels.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly Configuration _configuration;
        private readonly ILogger<ModuleRepository> _logger;

        public ModuleRepository(Configuration configuration, ILogger<ModuleRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public List<Module> GetAll()
        {
            var result = new List<Module>();

            try
            {
                using (var connection = new SqlConnection(_configuration.ConnectionString))
                {
                    connection.Open();
                    result = connection.Query<Module>("dbo.Modules_RetrieveAll", commandType: System.Data.CommandType.StoredProcedure).ToList();
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
