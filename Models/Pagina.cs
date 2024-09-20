using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaUs.Models
{
    [Table("Paginas")]
    public class Pagina
    {
        [Key]
        public int PaginaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [Display(Name = "Número da Página")]
        public int NumeroPagina { get; set; }

        // FK para Capitulo
        [ForeignKey("Capitulo")]
        public int CapituloId { get; set; }
        public Capitulo Capitulo { get; set; }

        [Required]
        public byte[] Imagem { get; set; } // Armazenamento da imagem como byte[]
    }
}