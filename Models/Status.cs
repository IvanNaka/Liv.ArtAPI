using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Status
{
    [Key]
    public string NomeStatus { get; set; }

    [StringLength(128)]
    public string NomeDescritivo { get; set; }

    public virtual ICollection<Proprietario>? Proprietario { get; set; }
    public virtual ICollection<Avaliador>? Avaliador { get; set; }
}