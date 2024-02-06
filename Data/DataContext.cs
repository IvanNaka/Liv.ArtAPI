using Microsoft.EntityFrameworkCore;

namespace LivArt
{
    public class LivArtContext : DbContext
    {
        public DbSet<Avaliador> Avaliador { get; set; } = null!;
        public DbSet<Cartao> Cartao { get; set; } = null!;
        public DbSet<Comprador> Comprador { get; set; } = null!;
        public DbSet<Curador> Curador { get; set; } = null!;
        public DbSet<Endereco> Endereco { get; set; } = null!;
        public DbSet<Lance> Lance { get; set; } = null!;
        public DbSet<Laudo> Laudo { get; set; } = null!;
        public DbSet<Leilao> Leilao { get; set; } = null!;
        public DbSet<Lote> Lote { get; set; } = null!;
        public DbSet<ObraArte> ObraArte { get; set; } = null!;
        public DbSet<Pagamento> Pagamento { get; set; } = null!;
        public DbSet<Proprietario> Proprietario { get; set; } = null!;
        public DbSet<Status> Status { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-VKHEAAQ\SQLEXPRESS;Database=LivArt;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pagamento>()
                .HasOne(p => p.Comprador)
                .WithMany(c => c.Pagamento)
                .HasForeignKey(p => p.CompradorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}