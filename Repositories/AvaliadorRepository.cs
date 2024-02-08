using LivArt;
using Microsoft.EntityFrameworkCore;

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

    public Avaliador? GetAvaliador(int avaliadorId){
        var avaliador = _context.Avaliador.SingleOrDefault(b => b.AvaliadorId==avaliadorId);
        return avaliador;
    }
    public List<Avaliador>? GetAvaliadores(){
        var avaliador = _context.Avaliador.AsQueryable().ToList();
        return avaliador;
    }
    public List<Avaliador>? GetCadastrosPendentes(){
        var listaCadastrosPendentes = _context.Avaliador.Where(b => b.StatusId=="pendente_avaliador").OrderBy(b => b.AvaliadorId).ToList();
        return listaCadastrosPendentes;
    }
    public Avaliador? UpdateStatusAvaliador(int avaliadorId, string statusId){
        Avaliador avaliador = this.GetAvaliador(avaliadorId);
        if (avaliador != null){
            avaliador.StatusId = statusId;
            _context.SaveChanges();
            return avaliador;
        }
        return null;
    }
}