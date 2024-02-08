using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LivArt;
public class LeilaoCadastroRepository
{

    public string Nome { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public string? Descricao { get; set; }

    public Leilao Cadastro()
    {
        Leilao leilaoObj = new Leilao();
        leilaoObj.Nome = this.Nome;
        leilaoObj.DataInicio = this.DataInicio;
        leilaoObj.DataFim = this.DataFim;
        leilaoObj.Descricao = this.Descricao;
        return leilaoObj;
    }
}