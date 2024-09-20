using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaUs.Models
{
    [Table("Capitulos")]
    public class Capitulo
    {
        [Key]
        public int CapituloId { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [Display(Name = "Número do Capítulo")]
        public int NumeroCapitulo { get; set; }

        [Display(Name = "Data de Atualização")]
        public DateTime DtAtualizacao { get; set; } = DateTime.Now; // Atualização automática

        // FK para Mangas
        [ForeignKey("Manga")]
        public int MangaId { get; set; }
        public Manga Manga { get; set; }

        // Lista de páginas relacionadas a este capítulo
        public ICollection<Pagina> Paginas { get; set; }
    }
}