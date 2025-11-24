using System.ComponentModel.DataAnnotations;

namespace ReelView.Core.DTOs.Usuario
{
    public class UsuarioLoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Senha { get; set; } = string.Empty;
    }
}