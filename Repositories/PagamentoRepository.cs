using LivArt;

public class PagamentoRepository
{
    private readonly LivArtContext _context;

    public PagamentoRepository(LivArtContext context){
        _context = context;
    }

    public void Save(Pagamento pagamento){
        _context.Pagamento.Add(pagamento);
        _context.SaveChanges();
    }
}