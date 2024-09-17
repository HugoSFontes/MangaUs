using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaUs.Models
{[Table("Mangas")]
    public class Manga
    {

        [Key]
        public int MangaId { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [MaxLength(100)]
        public string Titulo { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [MaxLength(100)]
        public string Autor { get; set; }
        
        [Required]
        public int GeneroId { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [Column(TypeName = "text")]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(255)]
        public string CapaManga { get; set; } 
        
        [Required]
        public int UsuarioId { get; set; }

        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtCriacao { get; set; }
        
    }
}
