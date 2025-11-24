namespace ReelView.Core.DTOs.Favorito
{
    public class FavoritoDTO
    {
        // O Id da Mídia que está sendo favoritada
        public int MidiaId { get; set; }

        // O Título da Mídia (necessário para exibição na lista de favoritos)
        public string Titulo { get; set; } = string.Empty;

        // URL da Capa (se o modelo Midia tiver essa propriedade)
        public string CapaUrl { get; set; } = string.Empty;

        // Opcional: Se for adicionar, adicione aqui o UsuarioId para criação
        // public int UsuarioId { get; set; }
    }
}