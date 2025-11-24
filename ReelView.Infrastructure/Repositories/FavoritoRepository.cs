using Microsoft.EntityFrameworkCore;
using ReelView.Core.Models;
using ReelView.Core.Interfaces.Repositories;
using ReelView.Infrastructure.Data;

namespace ReelView.Infrastructure.Repositories
{
    public class FavoritoRepository : BaseRepository<UsuarioFavorito>, IFavoritoRepository
    {
        public FavoritoRepository(AppDbContext context) : base(context)
        {
        }

        // IMPLEMENTAÇÃO NECESSÁRIA PELO IFavoritoRepository
        public async Task<IEnumerable<UsuarioFavorito>> GetByUsuarioIdAsync(int usuarioId)
        {
            // O Include é importante para carregar a informação da Mídia junto
            return await _context.Favoritos
                                 .Include(f => f.Midia)
                                 .Where(f => f.UsuarioId == usuarioId)
                                 .ToListAsync();
        }

        // IMPLEMENTAÇÃO NECESSÁRIA PARA DELETAR (CHAVE COMPOSTA)
        public async Task<UsuarioFavorito?> GetByUserAndMidiaAsync(int usuarioId, int midiaId)
        {
            return await _context.Favoritos
                                 .FirstOrDefaultAsync(f => f.UsuarioId == usuarioId && f.MidiaId == midiaId);
        }
    }
}