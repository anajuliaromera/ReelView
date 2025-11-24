using ReelView.Core.DTOs.Avaliacao;



namespace ReelView.Core.Interfaces.Service
{
    
    public interface IAvaliacaoService
    {
        Task AdicionarAvaliacaoAsync(AvaliacaoCreateDTO dto);
        Task<IEnumerable<AvaliacaoDTO>> GetAvaliacoesPorMidiaAsync(int midiaId);
    }
}