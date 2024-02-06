using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LivArt;
public class LaudoCadastroRepostory
{

    public string Status { get; set; }
    public string Autenticidade { get; set; }
    public double ValorEstimado { get; set; }
    public string? Observacoes { get; set; }
    public int ObraId { get; set; }

    public Laudo Cadastro(int? avaliadorId)
    {
        Laudo laudoObj = new Laudo();
        laudoObj.Status = Status;
        laudoObj.Autenticidade = this.Autenticidade;
        laudoObj.ValorEstimado = this.ValorEstimado;
        laudoObj.Observacoes = this.Observacoes;
        laudoObj.ObraId = this.ObraId;
        laudoObj.AvaliadorId = (int)avaliadorId;
        return laudoObj;
    }
}