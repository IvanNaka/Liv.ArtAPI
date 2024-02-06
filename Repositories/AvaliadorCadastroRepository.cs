using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LivArt;
public class AvaliadorCadastroRepostory
{

    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateOnly DataNascimento { get; set; }
    public string CPF { get; set; }
    public string CertificadoPath { get; set; }
    public string DocumentoPath { get; set; }
    public string Formacao { get; set; }
    public string Nacionalidade { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Username { get; set; }
    public string Senha { get; set; }

    public Avaliador AvaliadorCadastro()
    {
        string NomeCompleto = $"{this.Nome} {this.Sobrenome}";
        Avaliador avaliadorObj = new Avaliador();
        avaliadorObj.NomeCompleto = NomeCompleto;
        avaliadorObj.DataNascimento = this.DataNascimento;
        avaliadorObj.CertificadoPath = this.CertificadoPath;
        avaliadorObj.CPF = this.CPF;
        avaliadorObj.Nacionalidade = this.Nacionalidade;
        avaliadorObj.DocumentoPath = this.DocumentoPath;
        avaliadorObj.Formacao = this.Formacao;
        avaliadorObj.Email = this.Email;
        avaliadorObj.Telefone = this.Telefone;
        avaliadorObj.Username = this.Username;
        avaliadorObj.Senha = this.Senha;
        avaliadorObj.StatusId = "pendente_avaliador";
        return avaliadorObj;
    }
}