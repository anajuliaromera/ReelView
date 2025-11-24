namespace ReelView.Core.Models
{
    public class UsuarioFavorito
    {
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public int MidiaId { get; set; }
        public Midia? Midia { get; set; }
    }
}
