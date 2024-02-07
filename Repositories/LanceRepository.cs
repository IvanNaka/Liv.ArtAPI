using LivArt;

public interface ILanceRepository
{
    void Save(Lance lance);
}   

public class LanceRepository
{
    private readonly LivArtContext _context;
    
    public LanceRepository(LivArtContext context){
        _context = context;
    }

    public void Save(Lance lance){
        _context.Lance.Add(lance);
        _context.SaveChanges();
    }
}