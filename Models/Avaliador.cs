using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Avaliador
{
    [Key]
    public int AvaliadorId { get; set; }

    [StringLength(128)]
    public string NomeCompleto { get; set; }

    public DateTime DataNascimento { get; set; }

    [StringLength(256)]
    public string CertificadoPath { get; set; }

    [StringLength(256)]
    public string DocumentoPath { get; set; }
    
    [StringLength(256)]
    public string Formacao { get; set; }

    [StringLength(128)]
    public string Email { get; set; }

    [StringLength(16)]
    public string Telefone { get; set; }

    [ForeignKey("Curador")]
    public int? CuradorId { get; set; }
    public Curador? Curador { get; set; }

    [StringLength(128)]
    public string Username { get; set; }

    [StringLength(128)]
    public string Senha { get; set; }
}