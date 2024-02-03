using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Laudo
{
    [Key]
    public int LaudoId { get; set; }

    [StringLength(128)]
    public string Status { get; set; }

    [StringLength(256)]
    public string Autenticidade { get; set; }
    public double ValorEstimado { get; set; }

    [StringLength(256)]
    public string Observacoes { get; set; }

    [ForeignKey("Avaliador")]
    public int AvaliadorId { get; set; }
    public Avaliador Avaliador { get; set; }

    [ForeignKey("Obra")]
    public int ObraId { get; set; }
    public ObraArte Obra { get; set; }
}