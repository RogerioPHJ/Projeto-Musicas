using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FS.Musicas.Web.ViewModels.Musica
{
    public class MusicaViewModel
    {
        [Required(ErrorMessage = "O ID é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da musica é obrigatório")]
        [MaxLength(50, ErrorMessage = "O nome da musica pode ter no maximo 50 caracteres")]
        [Display(Name = "Nome da Musica")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Selecione um Album Valido")]
        [Display(Name = "Album")]
        public int IdAlbum { get; set; }



    }
}