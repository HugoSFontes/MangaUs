using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaUs.Models
{[Table("ProgressoLeituras")]
    public class ProgressoLeitura
    {
        
        [Key]
        public int ProgressoId { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public int MangaId { get; set; }
        [Required]
        public int CapituloId { get; set; }
        [Required]
        public int NumeroPagina { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime AtualizadoEm { get; set; }
        
    }
}
