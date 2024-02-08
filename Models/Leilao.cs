using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Leilao
{
    [Key]
    public int LeilaoId { get; set; }

    [StringLength(128)]
    public string Nome { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }

    [StringLength(256)]
    public string? Descricao { get; set; }
    public virtual ICollection<Lote>? Lote { get; set; }
}