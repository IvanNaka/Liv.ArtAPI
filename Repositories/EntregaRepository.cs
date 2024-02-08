using LivArt;
using Microsoft.EntityFrameworkCore;

public interface IEntregaRepository
{
    void Save(Entrega entrega);
}

public class EntregaRepository
{
    private readonly LivArtContext _context;

    public EntregaRepository(LivArtContext context)
    {
        _context = context;
    }

    public void Save(Entrega entrega)
    {
        _context.Entrega.Add(entrega);
        _context.SaveChanges();
    }
    public List<Entrega>? GetEntregaComprador(int compradorId)
    {
        var entrega = _context.Entrega.Include(e => e.Comprador).ThenInclude(c => c.Endereco).Where(b => b.CompradorId == compradorId).OrderByDescending(b => b.EntregaId).ToList();
        return entrega;
    }
    public List<Entrega>? GetTodasEntregas()
    {
        var entrega = _context.Entrega.OrderByDescending(b => b.EntregaId).ToList();
        return entrega;
    }
}