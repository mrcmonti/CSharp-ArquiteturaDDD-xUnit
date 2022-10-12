using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email é campo obrigatório para Login.")]
        [EmailAddress(ErrorMessage = "E-mail formato inválido.")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximp {1} caracteres.")]
        public string Email { get; set; }
    }
}
