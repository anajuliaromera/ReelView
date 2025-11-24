using Microsoft.AspNetCore.Mvc;
using ReelView.Core.DTOs.Serie;
using ReelView.Core.Interfaces.Service; 

namespace ReelView.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SerieController : ControllerBase
    {
        private readonly IMidiaService _service;

        public SerieController(IMidiaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SerieCreateDTO dto)
        {
            var result = await _service.CreateSerieAsync(dto);
            return CreatedAtAction("GetById", "Midia", new { id = result.Id }, result);
        }
    }
}