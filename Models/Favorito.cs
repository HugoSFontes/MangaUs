using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaUs.Models
{
    public class Favorito
    {

        [Key]
        public int FavoritoId { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public int MangaId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DtCriacao { get; set; }


        public Usuario Usuario { get; set; }
        public Manga Manga { get; set; }
    }
}
