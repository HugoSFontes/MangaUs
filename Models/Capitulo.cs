using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaUs.Models
{
    public class Capitulo
    {

        [Key]
        public int CapituloId { get; set; }
        [Required]
        public int NumeroCapitulo { get; set; }
        public DateTime DtCriacao { get; set; }
        public DateTime DtAtualizacao { get; set; }

        public int MangaId { get; set; }
        public Manga Manga { get; set; }
        public ICollection<Pagina> Paginas { get; set; }
    }
}
