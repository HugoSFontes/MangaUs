using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaUs.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }


        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [DisplayName("Nome")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage ="O campo {0} deve ser preenchido com e-mail valido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        [MaxLength(8, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string TipoUsuario { get; set; } // 'leitor' ou 'uploader'

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DtCriacao { get; set; }

  

       
        public ICollection<Manga> Mangas { get; set; } 
        public ICollection<Favorito> Favoritos { get; set; }
        public ICollection<ProgressoLeitura> ProgressoLeituras { get; set; }
    }
}
