using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Lote
{
    [Key]
    public int LoteId { get; set; }

    [StringLength(128)]
    public string Nome { get; set; }

    [StringLength(256)]
    public string Descricao { get; set; }

    public ICollection<ObraArte>? ObraArte { get; set; }
}