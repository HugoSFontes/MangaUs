using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<Manga> Mangas { get; set; } = default!;
        public DbSet<Usuario> Usuarios { get; set; } = default!;
        public DbSet<ProgressoLeitura> ProgressoLeituras { get; set; } = default!;
        public DbSet<Genero> Generos { get; set; } = default!;
        public DbSet<Favorito> Favoritos { get; set; } = default!;
        public DbSet<Capitulo> Capitulos { get; set; } = default!;
        public DbSet<Pagina> Paginas { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração para a entidade Usuario
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Mangas)
                .WithOne(m => m.Usuario)
                .HasForeignKey(m => m.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction); // Evita exclusão em cascata aqui para evitar loops

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Favoritos)
                .WithOne(f => f.Usuario)
                .HasForeignKey(f => f.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade); // Exclui favoritos quando o usuário for deletado

            // Aqui desativamos a exclusão em cascata para evitar ciclos
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.ProgressoLeituras)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction); // Evita exclusão em cascata aqui para evitar loops

            // Configuração para a entidade Manga
            modelBuilder.Entity<Manga>()
                .HasKey(m => m.MangaId);

            modelBuilder.Entity<Manga>()
                .HasMany(m => m.Capitulos)
                .WithOne(c => c.Manga)
                .HasForeignKey(c => c.MangaId)
                .OnDelete(DeleteBehavior.Cascade); // Exclui capítulos quando o manga for deletado

            // Aqui desativamos a exclusão em cascata para evitar ciclos
            modelBuilder.Entity<Manga>()
                .HasMany(m => m.ProgressoLeituras)
                .WithOne(p => p.Manga)
                .HasForeignKey(p => p.MangaId)
                .OnDelete(DeleteBehavior.NoAction); // Evita exclusão em cascata aqui para evitar loops

            modelBuilder.Entity<Manga>()
                .HasMany(m => m.Favoritos)
                .WithOne(f => f.Manga)
                .HasForeignKey(f => f.MangaId)
                .OnDelete(DeleteBehavior.NoAction); // Evita múltiplos caminhos em cascata

            // Configuração para a entidade Capitulo
            modelBuilder.Entity<Capitulo>()
                .HasKey(c => c.CapituloId);

            modelBuilder.Entity<Capitulo>()
                .HasMany(c => c.Paginas)
                .WithOne(p => p.Capitulo)
                .HasForeignKey(p => p.CapituloId)
                .OnDelete(DeleteBehavior.Cascade); // Exclui páginas quando o capítulo for deletado

            // Configuração para a entidade Favorito
            modelBuilder.Entity<Favorito>()
                .HasKey(f => f.FavoritoId);

            modelBuilder.Entity<Favorito>()
                .HasOne(f => f.Usuario)
                .WithMany(u => u.Favoritos)
                .HasForeignKey(f => f.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction); // Evita múltiplos caminhos em cascata

            modelBuilder.Entity<Favorito>()
                .HasOne(f => f.Manga)
                .WithMany(m => m.Favoritos)
                .HasForeignKey(f => f.MangaId)
                .OnDelete(DeleteBehavior.NoAction); // Evita múltiplos caminhos em cascata

            // Configuração para a entidade ProgressoLeitura
            modelBuilder.Entity<ProgressoLeitura>()
                .HasKey(p => p.ProgressoId);

            modelBuilder.Entity<ProgressoLeitura>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.ProgressoLeituras)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction); // Evita exclusão em cascata para evitar ciclos

            modelBuilder.Entity<ProgressoLeitura>()
                .HasOne(p => p.Manga)
                .WithMany(m => m.ProgressoLeituras)
                .HasForeignKey(p => p.MangaId)
                .OnDelete(DeleteBehavior.NoAction); // Evita múltiplos caminhos em cascata
        }



    }
}
