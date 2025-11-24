using ReelView.Core.DTOs.Midia;

namespace ReelView.Core.Interfaces.Service
{
    // Interface que define o contrato de consumo de dados externos.
    public interface IMediaExternalService
    {
        // Busca filmes populares. O DTO de retorno deve ser adaptado para a sua necessidade.
        Task<IEnumerable<MidiaDTO>> GetPopularMoviesAsync();

        // Busca mídia por nome (título).
        Task<IEnumerable<MidiaDTO>> SearchMediaAsync(string query);

        // Busca detalhes de uma mídia específica usando o ID da TMDB.
        Task<MidiaDTO> GetMediaDetailsAsync(int externalId);
    }
}