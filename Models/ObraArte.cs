using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class ObraArte
{
    [Key]
    public int ObraId { get; set; }

    [StringLength(256)]
    public string Artista { get; set; }

    [StringLength(256)]
    public string Titulo { get; set; }

    public DateOnly? DataCriacao { get; set; }

    [StringLength(128)]
    public string? Dimensao { get; set; }
    
    [StringLength(256)]
    public string Tecnica { get; set; }

    [StringLength(256)]
    public string Descricao { get; set; }

    [ForeignKey("Proprietario")]
    public int ProprietarioId { get; set; }
    public Proprietario Proprietario { get; set; }

    [ForeignKey("Avaliador")]
    public int? AvaliadorId { get; set; }
    public Avaliador? Avaliador { get; set; }

    [ForeignKey("Lote")]
    public int? LoteId { get; set; }
    public Lote? Lote { get; set; }
}