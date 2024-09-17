using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaUs.Models
{[Table("Generos")]
    public class Genero
    
    {

        [Key]
        public int GeneroId { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [MaxLength(30)]
        [DisplayName("Gênero")]
        public string Nome { get; set; }

    }
}
