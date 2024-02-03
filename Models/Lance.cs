using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Lance
{
    [Key]
    public int LanceId { get; set; }

    public double Valor { get; set; }

    public DateTime Data { get; set; }

    [ForeignKey("Comprador")]
    public int? CompradorId { get; set; }
    public Comprador? Comprador { get; set; }

    [ForeignKey("Leilao")]
    public int LeilaoId { get; set; }
    public Leilao? Leilao { get; set; }

}