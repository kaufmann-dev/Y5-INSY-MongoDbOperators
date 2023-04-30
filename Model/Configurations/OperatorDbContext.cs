using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Configurations;

public class OperatorDbContext : DbContext
{
    public DbSet<Operator> Operators { get; set; }
    public DbSet<AggregationOperator> AggregationOperators { get; set; }
    public DbSet<AggregationStage> AggregationStages { get; set; }
    
    public OperatorDbContext(DbContextOptions<OperatorDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Operator>()
            .HasIndex(x => x.Name)
            .IsUnique();

        builder.Entity<AggregationOperator>()
            .Property(c => c.Type)
            .HasConversion<string>();

        builder.Entity<OperatorCodeExamples>()
            .HasKey(x => new
            {
                x.OperatorId,
                x.CodeExampleId
            });

        builder.Entity<OperatorCodeExamples>()
            .HasOne(c => c.CodeExample)
            .WithMany(c=>c.Operators)
            .HasForeignKey(c => c.CodeExampleId);

        builder.Entity<OperatorCodeExamples>()
            .HasOne(c => c.Operator)
            .WithMany(v=>v.CodeExamples)
            .HasForeignKey(c => c.OperatorId);
    }
}