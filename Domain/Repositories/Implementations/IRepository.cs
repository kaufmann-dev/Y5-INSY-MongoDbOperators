namespace Domain.Repositories.Implementations;

public interface IRepository<TEntity>
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task<TEntity> ReadAsync(int id);
    Task<List<TEntity>> ReadAllAsync();
    Task DeleteAsync(TEntity entity);
}