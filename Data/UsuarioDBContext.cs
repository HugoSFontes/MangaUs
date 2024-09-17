using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MangaUs.Models;

namespace MangaUs.Data
{
    public class UsuarioDBContext : DbContext
    {
        public UsuarioDBContext(DbContextOptions<MangaDbContext> options)
        : base(options)
        {
        }
        
        public DbSet<Manga> Mangas { get; set; } = default!;
        public DbSet<Usuario> Usuarios { get; set; } = default!;
        public DbSet<ProgressoLeitura>ProgressoLeituras { get; set; } = default!;
        public DbSet<Genero> Generos { get; set; } = default!;
        public DbSet<Favorito> Favoritos { get; set; } = default!;
        public DbSet<Capitulo> Capitulos { get; set; } = default!;
        public DbSet<Pagina> Paginas { get; set; } = default!;





    

}