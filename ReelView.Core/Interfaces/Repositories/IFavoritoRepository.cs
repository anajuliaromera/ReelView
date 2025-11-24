using ReelView.Core.Models;

namespace ReelView.Core.Interfaces.Repositories
{
    public interface IFavoritoRepository : IBaseRepository<UsuarioFavorito>
    {
        Task<IEnumerable<UsuarioFavorito>> GetByUsuarioIdAsync(int usuarioId);
        // Necessário para deletar um favorito específico
        Task<UsuarioFavorito?> GetByUserAndMidiaAsync(int usuarioId, int midiaId);
    }
}