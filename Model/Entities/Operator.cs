using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Entities;

[Table("OPERATORS_BT")]
public abstract class Operator
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("OPERATOR_ID")]
    public int Id { get; set; }
    
    [Column("NAME")]
    [StringLength(45)]
    [Required]
    public string Name { get; set; }
    
    [Column("SYNTAX")]
    [StringLength(255)]
    [Required]
    public string Syntax { get; set; }
    
    [Column("SHORT_DESCRIPTION")]
    [StringLength(255)]
    public string? ShortDescription { get; set; }
    
    [Column("DESCRIPTION", TypeName = "text")]
    [StringLength(10000)]
    [Required]
    public string Description { get; set; }
    
    public List<OperatorCodeExamples> CodeExamples { get; set; }
}