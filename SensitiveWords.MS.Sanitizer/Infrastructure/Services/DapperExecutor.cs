using System.Data;
using Dapper;
using SensitiveWords.MS.Sanitizer.Infrastructure.Interfaces;

namespace SensitiveWords.MS.Sanitizer.Infrastructure.Services
{
    /// <summary>
    /// Dapper extention methods can not be mocked -- this is mainly for tests
    /// </summary>
    /// <seealso cref="IDapperExecutor" />
    public class DapperExecutor : IDapperExecutor
    {
        /// <summary>
        /// Queries the database asynchronously.
        /// </summary>
        /// <typeparam name="T">Type to convert result to</typeparam>
        /// <param name="connection">The connection (IDbConnection).</param>
        /// <param name="sql">The SQL (Raw or Stored proc).</param>
        /// <returns>
        /// IEnumerable of T
        /// </returns>
        public Task<IEnumerable<T>> QueryAsync<T>(IDbConnection connection, string sql)
            => connection.QueryAsync<T>(sql, commandType: CommandType.StoredProcedure);
        /// <summary>
        /// Executes the dappar scalar extension method asynchronously.
        /// </summary>
        /// <typeparam name="T">Type to convert result to</typeparam>
        /// <param name="connection">The connection (IDbConnection).</param>
        /// <param name="sql">The SQL (Raw or Stored proc).</param>
        /// <param name="param">The parameter.</param>
        /// <returns>
        /// bool/long/int
        /// </returns>
        public Task<T> ExecuteScalarAsync<T>(IDbConnection connection, string sql, object param)
            => connection.ExecuteScalarAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
        /// <summary>
        /// Queries the first or default asynchronous.
        /// </summary>
        /// <typeparam name="T">Type to convert result to</typeparam>
        /// <param name="connection">The connection (IDbConnection).</param>
        /// <param name="sql">The SQL (Raw or Stored proc).</param>
        /// <param name="param">The parameter.</param>
        /// <returns>
        /// First or Default of T
        /// </returns>
        public Task<T> QueryFirstOrDefaultAsync<T>(IDbConnection connection, string sql, object param)
            => connection.QueryFirstOrDefaultAsync<T>(sql, param, commandType: CommandType.StoredProcedure);
    }
}
