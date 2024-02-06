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
    public Avaliador? Login(string Username, string Senha){
        var user = _context.Avaliador.SingleOrDefault(x => x.Username == Username && x.Senha == Senha);
        if (user == null)
            {
                return null;
            }
        return user;
    }
}