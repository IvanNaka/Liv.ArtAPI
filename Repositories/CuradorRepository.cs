using LivArt;

public interface ICuradorRepository
{
    void Save(Avaliador avaliador);
    void Login (string Username, string Senha);
}   

public class CuradorRepository
{
    private readonly LivArtContext _context;
    
    public CuradorRepository(LivArtContext context){
        _context = context;
    }

    public void Save(Curador curador){
        _context.Curador.Add(curador);
        _context.SaveChanges();
    }
    public Curador? Login(string Username, string Senha){
        var user = _context.Curador.First(x => x.Username == Username && x.Senha == Senha);
        if (user == null)
            {
                return null;
            }
        return user;
    }
}