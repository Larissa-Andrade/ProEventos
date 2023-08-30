using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contextos
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) {
        }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lote { get; set; }
        public DbSet<Palestrante> Palestrante { get; set; }
        public DbSet<PalestranteEvento> PalestranteEvento { get; set; }
        public DbSet<RedeSocial> RedeSocial { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId});

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedeSocial)    
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
                .HasMany(p => p.RedeSocial)    
                .WithOne(rs => rs.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);    
        }
    }
}