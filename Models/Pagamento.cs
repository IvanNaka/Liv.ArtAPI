using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Pagamento
{
    [Key]
    public int PagamentoId { get; set; }

    public DateTime Data { get; set; }
    public double Valor { get; set; }

    [ForeignKey("Comprador")]
    public int CompradorId { get; set; }
    public Comprador Comprador { get; set; }

    [ForeignKey("Cartao")]
    public int CartaoId { get; set; }
    public Cartao Cartao { get; set; }

}