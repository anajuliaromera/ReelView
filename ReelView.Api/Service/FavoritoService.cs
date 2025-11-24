using ReelView.Core.DTOs.Favorito;
using ReelView.Core.Models; // Essencial para reconhecer a entidade UsuarioFavorito
using ReelView.Core.Interfaces.Repositories;
using ReelView.Core.Interfaces.Service;

namespace ReelView.Api.Service
{
    public class FavoritoService : IFavoritoService
    {
        private readonly IFavoritoRepository _repository;

        public FavoritoService(IFavoritoRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(FavoritoDTO dto)
        {
            // NOTA: Numa aplicação real com autenticação, o UsuarioId deve vir do 
            // HttpContext.User.Identity.Name ou Claims, e não hardcoded.
            // Como o DTO atual não tem UsuarioId, usamos um valor fixo temporário para compilar.

            // int userId = _httpContextAccessor.HttpContext.User...
            int userId = 1;

            var favorito = new UsuarioFavorito
            {
                MidiaId = dto.MidiaId,
                UsuarioId = userId
            };

            await _repository.AddAsync(favorito);
        }

        public async Task RemoveAsync(int usuarioId, int midiaId)
        {
            // Busca o favorito específico usando a chave composta (Usuário + Mídia)
            var favorito = await _repository.GetByUserAndMidiaAsync(usuarioId, midiaId);

            if (favorito != null)
            {
                await _repository.DeleteAsync(favorito);
            }
        }

        public async Task<IEnumerable<FavoritoDTO>> GetFavoritosUsuarioAsync(int usuarioId)
        {
            var favoritos = await _repository.GetByUsuarioIdAsync(usuarioId);

            // Mapeia a Entidade do banco para o DTO de resposta
            return favoritos.Select(f => new FavoritoDTO
            {
                MidiaId = f.MidiaId,
                // O operador ?. verifica se a Mídia foi carregada (Include) antes de acessar o Título
                Titulo = f.Midia?.Titulo ?? "Título Indisponível",
                // Se tiver URL da capa no modelo Midia, mapeie aqui:
                // CapaUrl = f.Midia?.CapaUrl 
            });
        }
    }
}