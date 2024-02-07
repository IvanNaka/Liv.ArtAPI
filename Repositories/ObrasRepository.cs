using LivArt;

public interface IObrasRepository
{
    void Save(Avaliador avaliador);
    void GetObrasAvaliador(string Username, string Senha);
}

public class ObrasArteRepository
{
    private readonly LivArtContext _context;

    public string? artista;
    public string? titulo;
    public DateOnly? dataCriacao;
    public string? tecnica;
    public string? proprietario;
    public int? loteId;
    public ObrasArteRepository(LivArtContext context)
    {
        _context = context;
    }


    public void Save(ObraArte ObraArte)
    {
        _context.ObraArte.Add(ObraArte);
        _context.SaveChanges();
    }

    public List<ObraArte>? GetObrasAvaliador(int? avaliadorId, ObrasArteFiltrosRepository filtros)
    {
        var listaObras = _context.ObraArte.Where(b => b.AvaliadorId.Equals(avaliadorId));
        if (!string.IsNullOrEmpty(filtros.artista))
        {
            listaObras = listaObras.Where(b => b.Artista.Equals(filtros.artista));
        }
        if (!string.IsNullOrEmpty(filtros.titulo))
        {
            listaObras = listaObras.Where(b => b.Titulo.Equals(filtros.titulo));
        }
        if (!string.IsNullOrEmpty(filtros.tecnica))
        {
            listaObras = listaObras.Where(b => b.Tecnica.Equals(filtros.tecnica));
        }
        if (!string.IsNullOrEmpty(filtros.proprietario))
        {
            listaObras = listaObras.Where(b => b.Proprietario.NomeCompleto.Equals(filtros.proprietario));
        }
        if (filtros.dataCriacao.HasValue)
        {
            listaObras = listaObras.Where(b => b.DataCriacao.Equals(filtros.dataCriacao));
        }
        return listaObras.OrderByDescending(b => b.ObraId).ToList();
    }
    public ObraArte? GetObrasId(int? obraId)
    {
        var obraArte = _context.ObraArte.SingleOrDefault(b => b.ObraId.Equals(obraId));
        return obraArte;
    }
    public List<ObraArte>? GetObras(ObrasArteFiltrosRepository filtros)
    {
        var listaObras = _context.ObraArte.AsQueryable();
        if (!string.IsNullOrEmpty(filtros.artista))
        {
            listaObras = listaObras.Where(b => b.Artista.Equals(filtros.artista));
        }
        if (!string.IsNullOrEmpty(filtros.titulo))
        {
            listaObras = listaObras.Where(b => b.Titulo.Equals(filtros.titulo));
        }
        if (!string.IsNullOrEmpty(filtros.tecnica))
        {
            listaObras = listaObras.Where(b => b.Tecnica.Equals(filtros.tecnica));
        }
        if (!string.IsNullOrEmpty(filtros.proprietario))
        {
            listaObras = listaObras.Where(b => b.Proprietario.NomeCompleto.Equals(filtros.proprietario));
        }
        if (filtros.loteId.HasValue)
        {
            listaObras = listaObras.Where(b => b.LoteId.Equals(filtros.loteId));
        }
        if (filtros.dataCriacao.HasValue)
        {
            listaObras = listaObras.Where(b => b.DataCriacao.Equals(filtros.dataCriacao));
        }
        return listaObras.OrderByDescending(b => b.ObraId).ToList();
    }
}