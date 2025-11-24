using ReelView.Core.DTOs.Avaliacao;
using ReelView.Core.Models; 
using ReelView.Core.Interfaces.Repositories;
using ReelView.Core.Interfaces.Service;

namespace ReelView.Api.Service
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _repository;

        public AvaliacaoService(IAvaliacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task AdicionarAvaliacaoAsync(AvaliacaoCreateDTO dto)
        {
            var avaliacao = new Avaliacao
            {
                UsuarioId = dto.UsuarioId,
                MidiaId = dto.MidiaId,
                Nota = dto.Nota,
                Comentario = dto.Comentario
            };
            await _repository.AddAsync(avaliacao);
        }

        public async Task<IEnumerable<AvaliacaoDTO>> GetAvaliacoesPorMidiaAsync(int midiaId)
        {
            
            var avaliacoes = await _repository.GetByMidiaIdAsync(midiaId);
            return avaliacoes.Select(a => new AvaliacaoDTO
            {
                Nota = a.Nota,
                Comentario = a.Comentario
                
            });
        }
    }
}