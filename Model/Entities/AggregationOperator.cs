using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("AGGREGATION_OPERATORS_ST")]
public class AggregationOperator : Operator
{
    [Column("TYPE")]
    [Required]
    public EAggregationOperatorType Type { get; set; }
}