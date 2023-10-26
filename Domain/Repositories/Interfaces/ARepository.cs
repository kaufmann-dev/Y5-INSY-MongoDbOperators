using Domain.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;

namespace Domain.Repositories.Interfaces;

public abstract class ARepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected OperatorDbContext _context;
    protected DbSet<TEntity> _table;

    public ARepository(OperatorDbContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>();
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _table.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _table.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity?> ReadAsync(int id)
    {
        return await _table.FindAsync(id);
    }

    public async Task<List<TEntity>> ReadAllAsync()
    {
        return await _table.ToListAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _table.Remove(entity);
        await _context.SaveChangesAsync();
    }
}