using Microsoft.AspNetCore.Mvc;
using ReelView.Core.DTOs.Avaliacao;
using ReelView.Core.Interfaces.Service; 

namespace ReelView.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _service;

        public AvaliacaoController(IAvaliacaoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AvaliacaoCreateDTO dto)
        {
            
            await _service.AdicionarAvaliacaoAsync(dto);

            
            return Created("", dto);
        }

        [HttpGet("midia/{midiaId:int}")]
        public async Task<IActionResult> GetPorMidia(int midiaId)
        {
            
            var avaliacoes = await _service.GetAvaliacoesPorMidiaAsync(midiaId);
            return Ok(avaliacoes);
        }
    }
}