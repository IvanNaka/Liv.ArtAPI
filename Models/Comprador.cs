using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Comprador
{
    [Key]
    public int CompradorId { get; set; }

    [StringLength(128)]
    public string NomeCompleto { get; set; }
    public DateOnly DataNascimento { get; set; }

    [StringLength(256)]
    public string DocumentoPath { get; set; }

    [StringLength(128)]
    public string Email { get; set; }

    [StringLength(16)]
    public string Telefone { get; set; }

    [ForeignKey("Endereco")]
    public int? EnderecoId { get; set; }
    public Endereco? Endereco { get; set; }
    public virtual ICollection<Pagamento>? Pagamento { get; set; }

    [StringLength(128)]
    public string Username { get; set; }

    [StringLength(128)]
    public string Senha { get; set; }
}