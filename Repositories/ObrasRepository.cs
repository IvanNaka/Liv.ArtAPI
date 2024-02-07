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
    public ObraArte UpdateLoteObra(int obraId, int loteId)
    {
        var obraArte = _context.ObraArte.SingleOrDefault(b => b.ObraId.Equals(obraId));
        obraArte.LoteId = loteId;
        _context.SaveChanges();
        return obraArte;
    }

    public ObraArte EditObra(ObrasArtePatchRepository filtros)
    {
        var obra = _context.ObraArte.SingleOrDefault(b => b.ObraId.Equals(filtros.obraId));
        if (!string.IsNullOrEmpty(filtros.artista))
        {
            obra.Artista = filtros.artista;
        }
        if (!string.IsNullOrEmpty(filtros.titulo))
        {
            obra.Titulo = filtros.titulo;
        }
        if (!string.IsNullOrEmpty(filtros.tecnica))
        {
            obra.Tecnica = filtros.tecnica;
        }
        if (filtros.loteId.HasValue)
        {
            obra.LoteId = filtros.loteId;
        }
        if (!string.IsNullOrEmpty(filtros.dimensao))
        {
            obra.Dimensao = filtros.dimensao;
        }
        if (!string.IsNullOrEmpty(filtros.descricao))
        {
            obra.Descricao = filtros.descricao;
        }
        if (filtros.dataCriacao.HasValue)
        {
            obra.DataCriacao = filtros.dataCriacao;
        }
        _context.SaveChanges();
        return obra;
    }
    public ObraArte DeleteObra(int obraId)
    {
        var obraArte = _context.ObraArte.SingleOrDefault(b => b.ObraId.Equals(obraId));
        _context.ObraArte.Remove(obraArte);
        _context.SaveChanges();
        return obraArte;
    }
}