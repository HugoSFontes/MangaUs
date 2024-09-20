using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaUs.Models
{
    [Table("Mangas")]
    public class Manga
    {
        [Key]
        public int MangaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        public string Descricao { get; set; }

        [DisplayName("Capa do Manga")]
        public byte[] CapaManga { get; set; } // Para armazenar a imagem diretamente como byte[]

        [DisplayName("Data de Criação")]
        public DateTime DtCriacao { get; set; } = DateTime.Now; // Gerada automaticamente

        // Relacionamento com capítulos
        public ICollection<Capitulo> Capitulos { get; set; }
    }
}