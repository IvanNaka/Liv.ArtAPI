using LivArt;

public interface ICartaoRepository
{
    void Save(Lance lance);
}   

public class CartaoRepository
{
    private readonly LivArtContext _context;
    
    public CartaoRepository(LivArtContext context){
        _context = context;
    }

    public void Save(Cartao cartao){
        _context.Cartao.Add(cartao);
        _context.SaveChanges();
    }
}