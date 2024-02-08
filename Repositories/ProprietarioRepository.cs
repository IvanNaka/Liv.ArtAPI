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
        var user = _context.Proprietario.First(x => x.Username == Username && x.Senha == Senha);
        if (user == null)
        {
            return null;
        }
        return user;
    }
    public Proprietario? GetProprietario(int proprietarioId){
        var proprietario = _context.Proprietario.First(b => b.ProprietarioId==proprietarioId);
        return proprietario;
    }
    public List<Proprietario>? GetCadastrosPendentes(){
        var listaCadastrosPendentes = _context.Proprietario.Where(b => b.StatusId=="pendente_proprietario").OrderBy(b => b.ProprietarioId).ToList();
        return listaCadastrosPendentes;
    }
    public Proprietario? UpdateStatusProprietario(int proprietarioId, string statusId){
        Proprietario proprietario = this.GetProprietario(proprietarioId);
        if (proprietario != null){
            proprietario.StatusId = statusId;
            _context.SaveChanges();
            return proprietario;
        }
        return null;
    }
}