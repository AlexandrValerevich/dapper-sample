using System.Data;
using DapperSample.Api.Interfaces;
using Npgsql;

namespace DapperSample.Api.Data;

public class FruitContext : IDbContext
{
    private readonly string _connectionString;
    public FruitContext(IConnectionStringOption option)
    {
        _connectionString = option.ConnectionString;
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
