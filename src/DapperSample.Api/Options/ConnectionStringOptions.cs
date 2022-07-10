using DapperSample.Api.Interfaces;

namespace DapperSample.Api.Options;

public class ConnectionStringOption : IConnectionStringOption
{
    public const string Name = "ConnectionStrings:Fruits";

    public string ConnectionString { get; set; }
}
