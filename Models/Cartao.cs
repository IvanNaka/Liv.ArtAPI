using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Cartao
{
    [Key]
    public int CartaoId { get; set; }

    [StringLength(128)]
    public string NomeEscrito { get; set; }

    [StringLength(5)]
    public string Validade { get; set; }

    [StringLength(5)]
    public string PrimeirosCinco { get; set; }

    [StringLength(64)]
    public string Hash { get; set; }
    

    [ForeignKey("Comprador")]
    public int CompradorId { get; set; }
    public Comprador Comprador { get; set; }
}