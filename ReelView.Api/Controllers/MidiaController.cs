using Microsoft.AspNetCore.Mvc;
using ReelView.Core.DTOs.Filme;
using ReelView.Core.DTOs.Midia;
using ReelView.Core.DTOs.Serie;
using ReelView.Core.Interfaces.Service;

namespace ReelView.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MidiaController : ControllerBase
    {
        private readonly IMidiaService _service;

        public MidiaController(IMidiaService service)
        {
            _service = service;
        }

        [HttpPost("filme")]
        public async Task<IActionResult> CreateFilme(FilmeCreateDTO dto)
        {
            var result = await _service.CreateFilmeAsync(dto);
            return Created("", result);
        }

        [HttpPost("serie")]
        public async Task<IActionResult> CreateSerie(SerieCreateDTO dto)
        {
            var result = await _service.CreateSerieAsync(dto);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MidiaUpdateDTO dto)
        {
            await _service.UpdateAsync(id, dto); 
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id); 
            return NoContent();
        }
    }
}