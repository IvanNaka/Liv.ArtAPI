using LivArt;

public class LoteRepository
{
    private readonly LivArtContext _context;

    public LoteRepository(LivArtContext context){
        _context = context;
    }

    public void Save(Lote lote){
        _context.Lote.Add(lote);
        _context.SaveChanges();
    }
    public Lote? GetLoteId(int? loteId){
        var lote = _context.Lote.First(b => b.LoteId.Equals(loteId));
        return lote;
    }
    public List<Lote>? GetLotes(){
        var listaLotes = _context.Lote.Where(b => b.Leilao.DataFim >= DateTime.Now).OrderByDescending(b => b.LeilaoId).ToList();
        return listaLotes;
    }
}