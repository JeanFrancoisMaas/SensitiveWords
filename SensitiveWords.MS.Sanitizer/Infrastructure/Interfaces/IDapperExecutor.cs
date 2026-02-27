using Dapper;
using System.Data;

namespace SensitiveWords.MS.Sanitizer.Infrastructure.Interfaces
{
    /// <summary>
    /// Abstraction of Dapper Extension methods (Mainly for Unit tests as they can not be mocked)
    /// </summary>
    public interface IDapperExecutor
    {
        /// <summary>
        /// Queries the database asynchronously.
        /// </summary>
        /// <typeparam name="T">Type to convert result to</typeparam>
        /// <param name="connection">The connection (IDbConnection).</param>
        /// <param name="sql">The SQL (Raw or Stored proc).</param>
        /// <returns>IEnumerable of T</returns>
        Task<IEnumerable<T>> QueryAsync<T>(IDbConnection connection, string sql);
        /// <summary>
        /// Executes the dappar scalar extension method asynchronously.
        /// </summary>
        /// <typeparam name="T">Type to convert result to</typeparam>
        /// <param name="connection">The connection (IDbConnection).</param>
        /// <param name="sql">The SQL (Raw or Stored proc).</param>
        /// <param name="param">The parameter.</param>
        /// <returns>bool/long/int</returns>
        Task<T> ExecuteScalarAsync<T>(IDbConnection connection, string sql, object param);
        /// <summary>
        /// Queries the first or default asynchronous.
        /// </summary>
        /// <typeparam name="T">Type to convert result to</typeparam>
        /// <param name="connection">The connection (IDbConnection).</param>
        /// <param name="sql">The SQL (Raw or Stored proc).</param>
        /// <param name="param">The parameter.</param>
        /// <returns>First or Default of T</returns>
        Task<T> QueryFirstOrDefaultAsync<T>(IDbConnection connection, string sql, object param);
    }
}
