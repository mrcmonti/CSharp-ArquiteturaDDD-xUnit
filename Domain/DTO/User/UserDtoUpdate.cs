using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos.User
{
    public class UserDtoUpdate
    {
        [Required(ErrorMessage = "Id é campo obrigatório")]
        public Guid Id { get; set; }
        [Required (ErrorMessage = "Nome é campo obrigatório")]
        [StringLength (60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email é campo obrigatório")]
        [EmailAddress (ErrorMessage = "Email em formato inválido")]
        [StringLength(60, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }

    }
}
