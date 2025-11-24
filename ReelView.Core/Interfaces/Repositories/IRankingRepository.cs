using ReelView.Core.DTOs.Ranking;

namespace ReelView.Core.Interfaces.Repositories
{
    public interface IRankingRepository
    {
        // Este é o método que estava faltando
        Task<IEnumerable<RankingDTO>> GetTopRatedAsync(int quantidade);
    }
}