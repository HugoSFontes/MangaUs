using Microsoft.EntityFrameworkCore;
using MangaUs.Models;

namespace MangaUs.Data
{
    public class MangaDbContext : DbContext
    {
        public MangaDbContext(DbContextOptions<MangaDbContext> options) 
            : base(options)
        {
        }

        // Definindo DbSets para as classes
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<Capitulo> Capitulos { get; set; }
        public DbSet<Pagina> Paginas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando relacionamento Manga -> Capitulo (1:N)
            modelBuilder.Entity<Capitulo>()
                .HasOne(c => c.Manga)
                .WithMany(m => m.Capitulos)
                .HasForeignKey(c => c.MangaId)
                .OnDelete(DeleteBehavior.Cascade); // Configurando cascata

            // Configurando relacionamento Capitulo -> Pagina (1:N)
            modelBuilder.Entity<Pagina>()
                .HasOne(p => p.Capitulo)
                .WithMany(c => c.Paginas)
                .HasForeignKey(p => p.CapituloId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
