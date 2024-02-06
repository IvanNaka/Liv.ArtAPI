using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LivArt;
public class CompradorCadastroRepostory
{

    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateOnly DataNascimento { get; set; }
    public string DocumentoPath { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Username { get; set; }
    public string Senha { get; set; }
    public string Logradouro { get; set; }
    public int Numero { get; set; }
    public string? Complemento { get; set; }
    public string Bairro { get; set; }
    public string Estado { get; set; }
    public string País { get; set; }

    public Endereco EnderecoCadastro()
    {
        Endereco enderecoObj = new Endereco();
        enderecoObj.Logradouro = this.Logradouro;   
        enderecoObj.Numero = this.Numero;
        enderecoObj.Complemento = this.Complemento;
        enderecoObj.Bairro = this.Bairro;
        enderecoObj.Estado = this.Estado;
        enderecoObj.País = this.País;
        return enderecoObj;
    }
    public Comprador CompradorCadastro(Endereco enderecoObj)
    {
        string NomeCompleto = $"{this.Nome} {this.Sobrenome}";
        Comprador compradorObj = new Comprador();
        compradorObj.NomeCompleto = NomeCompleto;
        compradorObj.DataNascimento = this.DataNascimento;
        compradorObj.DocumentoPath = this.DocumentoPath;
        compradorObj.Email = this.Email;
        compradorObj.Telefone = this.Telefone;
        compradorObj.Endereco = enderecoObj;
        compradorObj.Username = this.Username;
        compradorObj.Senha = this.Senha;
        return compradorObj;
    }
}