namespace DapperSample.Api.Interfaces;

public interface IRepository<TModel>
    where TModel : class
{
    Task<TModel> ReadAsync(Guid id);

    Task<TModel> CreateAsync(TModel createdModel);

    Task UpdateAsync(TModel updatedModel);

    Task DeleteAsync(Guid id);

    Task<IEnumerable<TModel>> ReadAllAsync();
}
