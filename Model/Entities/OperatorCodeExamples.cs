using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("OPERATOR_HAS_CODE_EXAMPLES")]
public class OperatorCodeExamples
{
    [Column("OPERATOR_ID")]
    public int OperatorId { get; set; }
    public Operator Operator { get; set; }
    
    [Column("CODE_EXAMPLE_ID")]
    public int CodeExampleId { get; set; }
    public CodeExample CodeExample { get; set; }
}