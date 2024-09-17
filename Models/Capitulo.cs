using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaUs.Models
{[Table("Capitulos")]
    public class Capitulo
    {

        [Key]
        public int CapituloId { get; set; }
        
        [Required]
        public int NumeroCapitulo { get; set; }
        
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtAtualizacao { get; set; }

        public int MangaId { get; set; }
        
        public int PaginaId { get; set; }
    }
}
