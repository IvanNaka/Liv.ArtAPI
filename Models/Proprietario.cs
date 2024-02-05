using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Proprietario
{
    [Key]
    public int ProprietarioId { get; set; }

    [StringLength(128)]
    public string NomeCompleto { get; set; }

    public DateTime DataNascimento { get; set; }

    [StringLength(256)]
    public string DocumentoPath { get; set; }

    [StringLength(128)]
    public string Email { get; set; }

    [StringLength(16)]
    public string Telefone { get; set; }

    [StringLength(128)]
    public string Username { get; set; }

    [StringLength(128)]
    public string Senha { get; set; }

    [ForeignKey("Endereco")]
    public int? EnderecoId { get; set; }
    public Endereco? Endereco { get; set; }

    [ForeignKey("Status")]
    public string StatusId { get; set; }
    public Status Status { get; set; }

    [ForeignKey("Curador")]
    public int? CuradorId { get; set; }
    public Curador? Curador { get; set; }
}