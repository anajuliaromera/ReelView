namespace ReelView.Core.DTOs.Midia
{
    public class MidiaUpdateDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
    }
}