using LivArt;

public interface IEnderecoRepository
{
    void Save(Endereco endereco);
}   

public class EnderecoRepository
{
    private readonly LivArtContext _context;
    
    public EnderecoRepository(LivArtContext context){
        _context = context;
    }

    public Endereco Save(Endereco endereco){
        _context.Endereco.Add(endereco);
        _context.SaveChanges();
        return endereco;
    }

    public Endereco GetEnderecoComprador(int compradorId){
        var comprador = _context.Comprador.First(b=>b.CompradorId==compradorId);
        var endereco = _context.Endereco.First(b=>b.EnderecoId==comprador.EnderecoId);
        return endereco;
    }
}