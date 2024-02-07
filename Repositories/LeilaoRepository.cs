using LivArt;

public class LeilaoRepository
{
    private readonly LivArtContext _context;

    public LeilaoRepository(LivArtContext context){
        _context = context;
    }

    public void Save(Leilao leilao){
        _context.Leilao.Add(leilao);
        _context.SaveChanges();
    }
    public Leilao? GetLeilaoId(int? LeilaoId){
        var leilao = _context.Leilao.SingleOrDefault(b => b.LeilaoId.Equals(LeilaoId));
        return leilao;
    }
    public List<Leilao>? GetLeiloes(){
        var listaObras = _context.Leilao.Where(b => b.DataFim >= DateTime.Now).OrderByDescending(b => b.LeilaoId).ToList();
        return listaObras;
    }
}