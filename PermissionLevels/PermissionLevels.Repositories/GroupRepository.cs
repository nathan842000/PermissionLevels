using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using PermissionLevels.DTOs;
using PermissionLevels.Repositories.Interfaces;

namespace PermissionLevels.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly Configuration _configuration;
        private readonly ILogger<GroupRepository> _logger;

        public GroupRepository(Configuration configuration, ILogger<GroupRepository> logger) 
        { 
            _configuration = configuration;
            _logger = logger;
        }

        public List<Group> GetAll()
        {
            var result = new List<Group>();

            try
            {
                using (var connection = new SqlConnection(_configuration.ConnectionString))
                {
                    connection.Open();
                    result = connection.Query<Group>("dbo.Groups_RetrieveAll", commandType: System.Data.CommandType.StoredProcedure).ToList();
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