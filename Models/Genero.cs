using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MangaUs.Models
{
    public class Genero
    {

        [Key]
        public int GeneroId { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [MaxLength(30)]
        [DisplayName("Gênero")]
        public string Nome { get; set; }

        
        public ICollection<Manga> Mangas { get; set; }
    }
}
