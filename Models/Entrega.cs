using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Entrega
{
    [Key]
    public int EntregaId { get; set; }

    public DateTime DataPrevista { get; set; }
    public string Status { get; set; }

    [ForeignKey("Pagamento")]
    public int PagamentoId { get; set; }
    public Pagamento Pagamento { get; set; }
    
    [ForeignKey("Proprietario")]
    public int ProprietarioId { get; set; }
    public Proprietario Proprietario { get; set; }
}