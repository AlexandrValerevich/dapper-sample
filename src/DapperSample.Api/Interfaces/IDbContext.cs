using System.Data;

namespace DapperSample.Api.Interfaces;

public interface IDbContext
{
    IDbConnection CreateConnection();
}
