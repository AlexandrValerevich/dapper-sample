
using Dapper;
using Dapper.Contrib.Extensions;
using DapperSample.Api.Interfaces;
using DapperSample.Api.Models;

namespace DapperSample.Api.Data;

public class FruitRepository : IRepository<Fruit>
{
    private readonly IDbContext _context;

    public FruitRepository(IDbContext context)
    {
        _context = context;
    }

    public async Task<Fruit> ReadAsync(Guid id)
    {
        var sql = @"SELECT * FROM ""Fruits"" WHERE ""Id"" = @Id";
        var parametrs = new DynamicParameters();
        parametrs.Add("Id", id);

        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<Fruit>(sql, parametrs);
    }

    public async Task<Fruit> CreateAsync(Fruit createdModel)
    {
        var sql = @"INSERT INTO public.""Fruits"" (""Name"", ""Count"") 
                        VALUES (@Name, @Count) RETURNING ""Id"" ";
        var parametrs = new DynamicParameters();
        parametrs.Add("Name", createdModel.Name);
        parametrs.Add("Count", createdModel.Count);

        using var connection = _context.CreateConnection();
        var id = await connection.ExecuteScalarAsync<Guid>(sql, parametrs);

        createdModel.Id = id;
        return createdModel;
    }

    public async Task<IEnumerable<Fruit>> ReadAllAsync()
    {
        using var connection = _context.CreateConnection();
        return await connection.GetAllAsync<Fruit>();
    }

    public async Task UpdateAsync(Fruit updatedModel)
    {
        using var connection = _context.CreateConnection();
        await connection.UpdateAsync(updatedModel);
    }

    public async Task DeleteAsync(Guid id)
    {
        using var connection = _context.CreateConnection();
        var deletedModel = await ReadAsync(id);
        await connection.DeleteAsync(deletedModel);
    }
}
