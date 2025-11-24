using ReelView.Core.DTOs.Favorito;

namespace ReelView.Core.Interfaces.Service
{
    public interface IFavoritoService
    {
        Task AddAsync(FavoritoDTO dto);

        // Correção: Recebe usuarioId e midiaId para identificar o favorito único
        Task RemoveAsync(int usuarioId, int midiaId);

        Task<IEnumerable<FavoritoDTO>> GetFavoritosUsuarioAsync(int usuarioId);
    }
}