using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Produto
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Nome { get; set; }

    [Required]
    public int Quantidade { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Preco { get; set; }
}