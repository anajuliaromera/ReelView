using Microsoft.AspNetCore.Mvc;
using ReelView.Core.Interfaces.Service;

namespace ReelView.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalController : ControllerBase
    {
        private readonly IMediaExternalService _externalService;

        public ExternalController(IMediaExternalService externalService)
        {
            _externalService = externalService;
        }

        
        [HttpGet("popular")]
        public async Task<IActionResult> GetPopular()
        {
            try
            {
                var movies = await _externalService.GetPopularMoviesAsync();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar filmes externos: {ex.Message}");
            }
        }
    }
}