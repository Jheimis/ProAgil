using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilContext : DbContext
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options):base(options){}
        public DbSet<Evento> eventos { get; set; }
        public DbSet<Palestrante> palestrantes { get; set; }
        public DbSet<PalestranteEvento> palestrantesEventos { get; set; }
        public DbSet<Lote> lotes { get; set; }
        public DbSet<RedeSocial> redesSociais { get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuilder){
            
            modelBuilder.Entity<PalestranteEvento>().HasKey(PE => new{PE.eventoId, PE.palestranteId});
        }

    }
}