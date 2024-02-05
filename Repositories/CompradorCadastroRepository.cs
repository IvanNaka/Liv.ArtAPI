using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LivArt;
public class CompradorCadastroRepostory
{

    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }
    public string CertificadoPath { get; set; }
    public string DocumentoPath { get; set; }
    public string Formacao { get; set; }
    public string Nacionalidade { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Username { get; set; }
    public string Senha { get; set; }

    public Comprador CompradorCadastro()
    {
        string NomeCompleto = $"{this.Nome} {this.Sobrenome}";
        Comprador compradorObj = new Comprador();
        compradorObj.NomeCompleto = NomeCompleto;
        compradorObj.DataNascimento = this.DataNascimento;
        compradorObj.DocumentoPath = this.DocumentoPath;
        compradorObj.Email = this.Email;
        compradorObj.Telefone = this.Telefone;
        compradorObj.Username = this.Username;
        compradorObj.Senha = this.Senha;
        return compradorObj;
    }
}