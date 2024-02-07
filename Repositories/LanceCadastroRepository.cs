using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LivArt;
public class LanceCadastroRepostory
{

    public double Valor { get; set; }
    public int LoteId { get; set; }
    public Lance Cadastro(int? compradorId)
    {
        Lance lanceObj = new Lance();
        lanceObj.Valor = this.Valor;
        lanceObj.Data = DateTime.Now;
        lanceObj.CompradorId = (int)compradorId;
        lanceObj.LoteId = this.LoteId;
        return lanceObj;
    }
}