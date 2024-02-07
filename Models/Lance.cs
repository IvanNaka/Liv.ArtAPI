using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Lance
{
    [Key]
    public int LanceId { get; set; }

    public double Valor { get; set; }

    public DateTime Data { get; set; }

    [ForeignKey("Comprador")]
    public int CompradorId { get; set; }
    public Comprador Comprador { get; set; }

    [ForeignKey("Lote")]
    public int LoteId { get; set; }
    public Lote Lote { get; set; }

}