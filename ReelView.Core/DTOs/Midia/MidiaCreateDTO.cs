using System.ComponentModel.DataAnnotations;

namespace ReelView.Core.DTOs.Midia
{
    public class MidiaCreateDTO
    {
        [Required]
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int Ano { get; set; }
    }
}