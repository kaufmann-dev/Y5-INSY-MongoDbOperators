using Domain.Repositories.Implementations;
using Model.Configurations;
using Model.Entities;

namespace Domain.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

public class CodeExampleRepository : ARepository<CodeExample>, ICodeExampleRepository
{
    public CodeExampleRepository(OperatorDbContext context) : base(context)
    {
    }

}