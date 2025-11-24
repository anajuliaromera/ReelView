using Microsoft.Extensions.Configuration;
using ReelView.Core.DTOs.Midia;
using ReelView.Core.Interfaces.Service;
using System.Text.Json;

namespace ReelView.Infrastructure.Clients
{
    // A TMDBClient fará a chamada HTTP real.
    // Ela depende do HttpClient e da configuração da API Key.
    public class TMDBClient : IMediaExternalService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public TMDBClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            // Lê a chave configurada no appsettings.json
            _apiKey = configuration["TMDB:ApiKey"] ?? throw new ArgumentNullException("TMDB:ApiKey não configurada.");
        }

        private async Task<string> GetJsonAsync(string path)
        {
            // Adiciona a chave da API e a linguagem à URL
            var url = $"{path}?api_key={_apiKey}&language=pt-BR";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<IEnumerable<MidiaDTO>> GetPopularMoviesAsync()
        {
            var json = await GetJsonAsync("movie/popular");

            // Desserializa a resposta da TMDB para um objeto intermediário
            using var doc = JsonDocument.Parse(json);
            var results = doc.RootElement.GetProperty("results").EnumerateArray();

            var midias = new List<MidiaDTO>();
            foreach (var result in results)
            {
                // Mapeamento manual dos campos da TMDB para o seu MidiaDTO
                midias.Add(new MidiaDTO
                {
                    Id = result.GetProperty("id").GetInt32(),
                    Titulo = result.GetProperty("title").GetString() ?? "Título Indisponível",
                    Ano = result.TryGetProperty("release_date", out var date) && date.GetString()?.Length >= 4 ? int.Parse(date.GetString().Substring(0, 4)) : 0,
                    // O campo 'Tipo' será "Filme" para TMDB movies.
                    Tipo = "Filme"
                });
            }
            return midias;
        }

        // TODO: Implementar SearchMediaAsync e GetMediaDetailsAsync de forma similar.

        public Task<IEnumerable<MidiaDTO>> SearchMediaAsync(string query)
        {
            // Implementação
            throw new NotImplementedException();
        }

        public Task<MidiaDTO> GetMediaDetailsAsync(int externalId)
        {
            // Implementação
            throw new NotImplementedException();
        }
    }
}