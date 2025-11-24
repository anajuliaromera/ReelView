namespace ReelView.Core.DTOs.Avaliacao
{
    public class AvaliacaoCreateDTO
    {
        public int Nota { get; set; }
        public string Comentario { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
        public int MidiaId { get; set; }
    }
}
