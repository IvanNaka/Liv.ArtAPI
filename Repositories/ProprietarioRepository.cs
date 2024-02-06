using LivArt;

public interface IProprietarioRepository
{
    void Save(Proprietario proprietario);
    void Login(string Username, string Senha);
}

public class ProprietarioRepository
{
    private readonly LivArtContext _context;

    public ProprietarioRepository(LivArtContext context)
    {
        _context = context;
    }

    public void Save(Proprietario proprietario)
    {
        _context.Proprietario.Add(proprietario);
        _context.SaveChanges();
    }
    public Proprietario? Login(string Username, string Senha)
    {
        var user = _context.Proprietario.SingleOrDefault(x => x.Username == Username && x.Senha == Senha);
        if (user == null)
        {
            return null;
        }
        return user;
    }
}