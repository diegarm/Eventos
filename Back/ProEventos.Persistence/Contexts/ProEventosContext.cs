using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Contexts
{
    public class ProEventosContext : DbContext 
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }

        public DbSet<Lote> Lotes { get; set; }

        public DbSet<Palestrante> Palestrantes { get; set; }

        public DbSet<PalestranteEvento> PalestranteEvento { get; set; }

        public DbSet<RedeSocial> RedeSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relaciona a Tabela Palestrante com Evento
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId });

            //Cascateia o Delete
            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Palestrante>()
                .HasMany(e => e.RedeSociais)
                .WithOne(rs => rs.palestrante)
                .OnDelete(DeleteBehavior.Cascade);


        }


    }
}
