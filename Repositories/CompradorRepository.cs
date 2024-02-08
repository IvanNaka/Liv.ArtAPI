using LivArt;

public interface ICompradorRepository
{
    void Save(Comprador comprador);
    void Login(string Username, string Senha);
}

public class CompradorRepository
{
    private readonly LivArtContext _context;

    public CompradorRepository(LivArtContext context)
    {
        _context = context;
    }

    public void Save(Comprador comprador)
    {
        _context.Comprador.Add(comprador);
        _context.SaveChanges();
    }
    public Comprador? Login(string Username, string Senha)
    {
        var user = _context.Comprador.First(x => x.Username == Username && x.Senha == Senha);
        if (user == null)
        {
            return null;
        }
        return user;
    }
}