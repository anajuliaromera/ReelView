using Microsoft.AspNetCore.Mvc;
using ReelView.Core.DTOs.Favorito;
using ReelView.Core.Interfaces.Service;

namespace ReelView.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritoController : ControllerBase
    {
        private readonly IFavoritoService _service;

        public FavoritoController(IFavoritoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] FavoritoDTO dto)
        {
            await _service.AddAsync(dto);
            return Ok(new { message = "Adicionado aos favoritos com sucesso." });
        }

        
        [HttpDelete("{usuarioId}/{midiaId}")]
        public async Task<IActionResult> Remover(int usuarioId, int midiaId)
        {
            await _service.RemoveAsync(usuarioId, midiaId);
            return NoContent();
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> ListarPorUsuario(int usuarioId)
        {
            var favoritos = await _service.GetFavoritosUsuarioAsync(usuarioId);
            return Ok(favoritos);
        }
    }
}