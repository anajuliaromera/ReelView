using Microsoft.AspNetCore.Mvc;
using ReelView.Core.DTOs.Filme;
using ReelView.Core.Interfaces.Service; 

namespace ReelView.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IMidiaService _service;

        public FilmeController(IMidiaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(FilmeCreateDTO dto)
        {
            var result = await _service.CreateFilmeAsync(dto);
            return CreatedAtAction("GetById", "Midia", new { id = result.Id }, result);
        }
    }
}