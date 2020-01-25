using FS.Musicas.Web.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FS.Musicas.Web.ViewModels.Album
{
    public class AlbumViewModel
    {
        [Required (ErrorMessage = "O ID é obrigatório")]
        public int Id { get; set; }

        [Display(Name = "Nome do album")]
        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do album terá no maximo 100 caracteres")]
        public string Nome { get; set; }
        [Display(Name = "Ano do album")]
        [Required(ErrorMessage = "O Ano é obrigatório")]
        public int Ano { get; set; }

        [Display(Name = "Observações")]
        [MaxLength(1000, ErrorMessage = "Excedida a quantidade de caracteres para a observação, que é no maximo de 1000 caracateres")]
        public string Observacoes { get; set; }

        [Display(Name = "Email de Contato")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "O Email é obrigatório")]
        [MaxLength(50, ErrorMessage = "O email não pode ter mais que 50 caracteres")]
        [EmailGmail (ErrorMessage = "O Email deve ser do Gmail")]
        public string Email { get; set; }

    }
}