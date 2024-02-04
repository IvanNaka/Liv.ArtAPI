using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Status
{
    [Key]
    public string NomeStatus { get; set; }

    [StringLength(128)]
    public string NomeDescritivo { get; set; }

}