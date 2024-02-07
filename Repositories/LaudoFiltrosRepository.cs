using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LivArt;
public class LaudosFiltroRepository
{

    public string? Status { get; set; }
    public string? Autenticidade { get; set; }
    public double? ValorEstimado { get; set; }
    public int? ObraId { get; set; }

}