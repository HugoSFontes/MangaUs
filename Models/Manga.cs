using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaUs.Models
{
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
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        public int GeneroId { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [Column(TypeName = "text")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [MaxLength(255)]
        public string CapaManga { get; set; } 
        [Required]
        [HiddenInput(DisplayValue = false)]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [DataType(DataType.Date)]
        [DisplayName("Data de publicação")]
        public DateTime DtCriacao { get; set; }

        
        public Genero Genero { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Capitulo> Capitulos { get; set; }
        public ICollection<Favorito> Favoritos { get; set; }
        public ICollection<ProgressoLeitura> ProgressoLeituras { get; set; }
    }
}
