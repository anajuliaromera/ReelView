using Microsoft.EntityFrameworkCore;
using ReelView.Core.DTOs.Ranking;
using ReelView.Core.Interfaces.Repositories;
using ReelView.Infrastructure.Data;

namespace ReelView.Infrastructure.Repositories
{
    // Implementação simples: Busca as mídias com maior nota média
    public class RankingRepository : IRankingRepository
    {
        private readonly AppDbContext _context;

        public RankingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RankingDTO>> GetTopRatedAsync(int quantidade)
        {
            // Como o NotaMedia é calculado em memória (não está no banco), 
            // precisamos trazer os dados e ordenar na memória ou criar uma view.
            // Para simplificar e evitar erro de tradução do LINQ, trazemos tudo e ordenamos.
            // (Em produção, NotaMedia deveria ser uma coluna persistida para performance).

            var midias = await _context.Midias
                                       .Include(m => m.Avaliacoes)
                                       .ToListAsync();

            return midias
                .OrderByDescending(m => m.NotaMedia)
                .Take(quantidade)
                .Select(m => new RankingDTO
                {
                    MidiaId = m.Id,
                    Titulo = m.Titulo,
                    NotaMedia = m.NotaMedia,
                    // CapaUrl = m.CapaUrl // Descomente se tiver essa propriedade
                });
        }
    }
}