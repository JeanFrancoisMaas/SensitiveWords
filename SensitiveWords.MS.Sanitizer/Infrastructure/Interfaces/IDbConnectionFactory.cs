using System.Data;
namespace SensitiveWords.MS.Sanitizer.Infrastructure.Interfaces
{
    /// <summary>
    /// Responsible for creating database connections
    /// </summary>
    public interface IDbConnectionFactory
    {
        /// <summary>
        /// Creates the database connection.
        /// </summary>
        /// <returns>IDbConnection</returns>
        IDbConnection CreateConnection();
    }
}
