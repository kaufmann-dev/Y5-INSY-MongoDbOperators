using Domain.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Interfaces;

public class AggregationStageRepository : ARepository<AggregationStage>, IAggregationStageRepository
{
    public AggregationStageRepository(OperatorDbContext context) : base(context)
    {
    }

    public async Task<AggregationStage> ReadAsync(int id)
    {
        return await _table
            .Include(c => c.CodeExamples)
            .Where(c => c.Id == id)
            .SingleOrDefaultAsync();
    }
}