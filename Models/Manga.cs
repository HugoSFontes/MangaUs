using Microsoft.AspNetCore.Mvc;
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
        [Required]
        public int GeneroId { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [Column(TypeName = "text")]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(255)]
        [HiddenInput(DisplayValue = false)]
        public string CapaManga { get; set; } 
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DtCriacao { get; set; }

        
        public Genero Genero { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Capitulo> Capitulos { get; set; }
        public ICollection<Favorito> Favoritos { get; set; }
        public ICollection<ProgressoLeitura> ProgressoLeituras { get; set; }
    }
}
