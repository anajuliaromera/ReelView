using ReelView.Core.DTOs.Ranking;
using ReelView.Core.Interfaces.Repositories;
using ReelView.Core.Interfaces.Service;

namespace ReelView.Api.Service
{
    public class RankingService : IRankingService
    {
        private readonly IRankingRepository _repository;

        public RankingService(IRankingRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RankingDTO>> GetTop10Async()
        {
            // Chama o repositório para buscar os 10 melhores
            // O método no repositório deve retornar IEnumerable<RankingDTO> ou Entidades que mapeamos aqui
            // Assumindo que o repositório já retorna o DTO ou faz a projeção:
            return await _repository.GetTopRatedAsync(10);
        }
    }
}