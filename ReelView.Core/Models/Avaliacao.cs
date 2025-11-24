namespace ReelView.Core.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int Nota { get; set; }
        public string Comentario { get; set; } = string.Empty;

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public int MidiaId { get; set; }
        public Midia? Midia { get; set; }
    }
}
