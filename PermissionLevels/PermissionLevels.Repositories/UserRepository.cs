using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using PermissionLevels.DTOs;
using PermissionLevels.Repositories.Interfaces;

namespace PermissionLevels.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Configuration _configuration;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(Configuration configuration, ILogger<UserRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public List<User> GetAll()
        {
            var result = new List<User>();

            try
            {
                using (var connection = new SqlConnection(_configuration.ConnectionString))
                {
                    connection.Open();
                    result = connection.Query<User>("dbo.Users_RetrieveAll", commandType: System.Data.CommandType.StoredProcedure).ToList();
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
