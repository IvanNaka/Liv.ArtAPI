using LivArt;

public interface IAvaliadorRepository
{
    void Save(Avaliador avaliador);
}   

public class AvaliadorRepository
{
    private readonly LivArtContext _context;
    
    public AvaliadorRepository(LivArtContext context){
        _context = context;
    }

    public void Save(Avaliador avaliador){
        _context.Avaliador.Add(avaliador);
        _context.SaveChanges();
    }
}