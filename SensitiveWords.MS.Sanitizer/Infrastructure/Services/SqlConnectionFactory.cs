using Microsoft.Data.SqlClient;
using SensitiveWords.MS.Sanitizer.Infrastructure.Interfaces;
using System.Data;

namespace SensitiveWords.MS.Sanitizer.Infrastructure.Services
{
    /// <summary>
    /// Factory Responsible for creating database connections
    /// </summary>
    /// <seealso cref="SensitiveWords.MS.Sanitizer.Infrastructure.Interfaces.IDbConnectionFactory" />
    public class SqlConnectionFactory :IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlConnectionFactory"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Creates the database connection.
        /// </summary>
        /// <returns>
        /// IDbConnection
        /// </returns>
        public IDbConnection CreateConnection() => new SqlConnection(_configuration.GetConnectionString("sanitizedb"));
    }
}
