using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LivArt;
public class PagamentoCadastroRepostory
{

    public DateTime Data { get; set; }
    public double ValorFinal { get; set; }
    public int LoteId { get; set; }
    public string NomeEscritoCartao { get; set; }
    public string ValidadeCartao { get; set; }
    public string PrimeirosCincoCartao { get; set; }

    public string HashCartao { get; set; }
    public Cartao CadastroCartao(int? compradorId)
    {
        Cartao cartaoObj = new Cartao();
        cartaoObj.NomeEscrito = this.NomeEscritoCartao;
        cartaoObj.Validade = this.ValidadeCartao;
        cartaoObj.PrimeirosCinco = this.PrimeirosCincoCartao;
        cartaoObj.Hash = HashConstructor.CreateHash(this.HashCartao);
        return cartaoObj;
    }
    public Pagamento CadastroPagamento(int? compradorId, int cartaoId)
    {
        Pagamento pagamentoObj = new Pagamento();
        pagamentoObj.ValorFinal = this.ValorFinal;
        pagamentoObj.ValorProprietario = this.ValorFinal*0.93;
        pagamentoObj.ValorAvaliador = this.ValorFinal*0.05;
        pagamentoObj.LoteId = this.LoteId;
        pagamentoObj.CompradorId = (int)compradorId;
        pagamentoObj.CartaoId = (int)cartaoId;
        pagamentoObj.Data = DateTime.Now;
        return pagamentoObj;
    }
}