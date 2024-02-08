using LivArt;

public interface ILaudoRepository
{
    void Save(Laudo laudo);
}   

public class LaudoRepository
{
    private readonly LivArtContext _context;
    
    public LaudoRepository(LivArtContext context){
        _context = context;
    }

    public void Save(Laudo laudo){
        _context.Laudo.Add(laudo);
        _context.SaveChanges();
    }
    public Laudo? GetLaudo(int laudoId){
        var laudo = _context.Laudo.First(b => b.LaudoId==laudoId);
        return laudo;
    }
    public List<Laudo>? GetLaudos(LaudosFiltroRepository filtros){
        var listaLaudos = _context.Laudo.AsQueryable();
        if (!string.IsNullOrEmpty(filtros.Status))
        {
            listaLaudos = listaLaudos.Where(b => b.Status.Equals(filtros.Status));
        }
        if (!string.IsNullOrEmpty(filtros.Autenticidade))
        {
            listaLaudos = listaLaudos.Where(b => b.Autenticidade.Equals(filtros.Autenticidade));
        }
        if (filtros.ValorEstimado.HasValue)
        {
            listaLaudos = listaLaudos.Where(b => b.ValorEstimado.Equals(filtros.ValorEstimado));
        }
        if (filtros.ObraId.HasValue)
        {
            listaLaudos = listaLaudos.Where(b => b.ObraId.Equals(filtros.ObraId));
        }
    
        return listaLaudos.OrderByDescending(b=>b.LaudoId).ToList();
    }
}