using LivArt;

public interface IObrasRepository
{
    void Save(Avaliador avaliador);
    void GetObrasAvaliador (string Username, string Senha);
}   

public class ObrasArteRepository
{
    private readonly LivArtContext _context;

    public string? artista;
    public string? titulo;
    public DateTime? dataCriacao;
    public string? tecnica;
    public string? proprietario;
    public ObrasArteRepository(LivArtContext context){
        _context = context;
    }

    public void Save(Avaliador avaliador){
        _context.Avaliador.Add(avaliador);
        _context.SaveChanges();
    }
    public List<ObraArte>? GetObrasAvaliador(int? avaliadorId, ObrasArteRepository filtros){
        var listaObras = _context.ObraArte.Where(b => b.AvaliadorId.Equals(avaliadorId));
        if (!string.IsNullOrEmpty(filtros.artista)){
            listaObras = listaObras.Where(b => b.Artista.Equals(filtros.artista));
        }
        if (!string.IsNullOrEmpty(filtros.titulo)){
            listaObras = listaObras.Where(b => b.Titulo.Equals(filtros.titulo));
        }
        if (!string.IsNullOrEmpty(filtros.tecnica)){
            listaObras = listaObras.Where(b => b.Tecnica.Equals(filtros.tecnica));
        }
        if (!string.IsNullOrEmpty(filtros.proprietario)){
            listaObras = listaObras.Where(b => b.Proprietario.NomeCompleto.Equals(filtros.proprietario));
        }
        if (filtros.dataCriacao.HasValue){
            listaObras = listaObras.Where(b => b.DataCriacao.Equals(filtros.dataCriacao));
        }
        return listaObras.ToList();
    }
}