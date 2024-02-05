using LivArt;

public interface IAvaliadorRepository
{
    void Save(Avaliador avaliador);
    void Login (string Username, string Senha);
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
    public Avaliador? Login(string Username, string Senha){
        var user = _context.Avaliador.SingleOrDefault(x => x.Username == Username && x.Senha == Senha);
        if (user == null)
            {
                return null;
            }
        return user;
    }
}