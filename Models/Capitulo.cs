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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DtCriacao { get; set; }

        public int MangaId { get; set; }
        public Manga Manga { get; set; }
        public ICollection<Pagina> Paginas { get; set; }
    }
}
