using System.Data;
using Altavix.Application.Interfaces;
using Dapper;

namespace Altavix.Application.Features;

public abstract class BaseQueryHandler
{
    private readonly IDbConnectionFactory _connectionProvider;

    protected BaseQueryHandler(IDbConnectionFactory connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    protected async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        using var connection = _connectionProvider.CreateConnection();
        return await connection.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
    }

    protected async Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        using var connection = _connectionProvider.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
    }

    protected async Task<T> QuerySingleAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        using var connection = _connectionProvider.CreateConnection();
        return await connection.QuerySingleAsync<T>(sql, param, transaction, commandTimeout, commandType);
    }

    protected async Task<TResult> QueryMultipleAsync<TResult>(
        string sql, 
        Func<SqlMapper.GridReader, Task<TResult>> mapFunc, 
        object? param = null, 
        IDbTransaction? transaction = null, 
        int? commandTimeout = null, 
        CommandType? commandType = null)
    {
        using var connection = _connectionProvider.CreateConnection();
        using var gridReader = await connection.QueryMultipleAsync(sql, param, transaction, commandTimeout, commandType);
        return await mapFunc(gridReader);
    }

    protected async Task<T?> ExecuteScalarAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        using var connection = _connectionProvider.CreateConnection();
        return await connection.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType);
    }
}
