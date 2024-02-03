using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Endereco
{
    [Key]
    public int EnderecoId { get; set; }

    [StringLength(128)]
    public string Logradouro { get; set; }

    public int Numero { get; set; }

    [StringLength(256)]
    public string Complemento { get; set; }
    
    [StringLength(64)]
    public string Bairro { get; set; }

    [StringLength(64)]
    public string Estado { get; set; }

    [StringLength(64)]
    public string País { get; set; }
}