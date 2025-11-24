using ReelView.Core.DTOs.Ranking;

namespace ReelView.Core.Interfaces.Service
{
    public interface IRankingService
    {
        Task<IEnumerable<RankingDTO>> GetTop10Async();
    }
}