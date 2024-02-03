using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Curador
{
    [Key]
    public int CuradorId { get; set; }

    [StringLength(128)]
    public string NomeCompleto { get; set; }

    public DateTime DataNascimento { get; set; }

    [StringLength(128)]
    public string Formacao { get; set; }

    [StringLength(256)]
    public string DocumentoPath { get; set; }

    [StringLength(128)]
    public string Username { get; set; }

    [StringLength(128)]
    public string Senha { get; set; }

}