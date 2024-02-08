using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LivArt;
public class LoteCadastroRepostory
{

    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int LeilaoId { get; set; }
    public Lote Cadastro()
    {
        Lote loteObj = new Lote();
        loteObj.Nome = this.Nome;
        loteObj.LeilaoId = this.LeilaoId;
        loteObj.Descricao = this.Descricao;
        return loteObj;
    }
}