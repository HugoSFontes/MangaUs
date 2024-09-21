using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaUs.Models
{
    public class Favorito
    {

        [Key]
        public int FavoritoId { get; set; }
       
        public int UsuarioId { get; set; }
        
        public int MangaId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DtCriacao { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [ForeignKey("MangaId")]
        public Manga Manga { get; set; }
    }
}
