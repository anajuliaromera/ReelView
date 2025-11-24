using Microsoft.EntityFrameworkCore;
using ReelView.Core.Models;
using ReelView.Core.Interfaces.Repositories;
using ReelView.Infrastructure.Data;

namespace ReelView.Infrastructure.Repositories
{
    public class AvaliacaoRepository : BaseRepository<Avaliacao>, IAvaliacaoRepository
    {
        public AvaliacaoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Avaliacao>> GetByMidiaIdAsync(int midiaId)
        {
            return await _context.Avaliacoes
                                 .Where(a => a.MidiaId == midiaId)
                                 .ToListAsync();
        }
    }
}