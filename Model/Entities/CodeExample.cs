using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("CODE_EXAMPLES_ST")]
public class CodeExample
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("CODE_EXAMPLE_ID")]
    public int Id { get; set; }
    
    [Column("DESCRIPTION", TypeName = "text")]
    public string? Description { get; set; }
    
    [Required]
    [Column("CODE", TypeName = "text")]
    public string Code { get; set; }
    
    public List<OperatorCodeExamples> Operators { get; set; }
}