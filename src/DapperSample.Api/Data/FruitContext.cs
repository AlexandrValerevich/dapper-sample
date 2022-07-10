using System.Data;
using DapperSample.Api.Interfaces;
using DapperSample.Api.Models;
using Microsoft.EntityFrameworkCore;
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

    // protected FruitContext()
    // {
    // }

    // public FruitContext(DbContextOptions<FruitContext> options) : base(options)
    // {
    // }

    // public DbSet<Fruit> Fruits { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.HasPostgresExtension("uuid-ossp");
    //     modelBuilder.Entity<Fruit>()
    //         .HasKey(x => x.Id);

    //     modelBuilder.Entity<Fruit>()
    //         .Property(x => x.Id)
    //         .ValueGeneratedOnAdd()
    //         .HasDefaultValueSql("uuid_generate_v4()");
    // }

}
