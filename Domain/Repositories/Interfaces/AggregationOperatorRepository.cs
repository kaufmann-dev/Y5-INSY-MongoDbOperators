using Domain.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Interfaces;

public class AggregationOperatorRepository : ARepository<AggregationOperator>, IAggregationOperatorRepository
{
    public AggregationOperatorRepository(OperatorDbContext context) : base(context)
    {
        
    }

    public async Task<AggregationOperator?> ReadAsync(int id)
    {
        return await _table
            .Include(c => c.CodeExamples)
            .ThenInclude(c=>c.CodeExample)
            .Where(c => c.Id == id)
            .SingleOrDefaultAsync();
    }
}