using Microsoft.AspNetCore.Mvc;
using ReelView.Core.DTOs.Usuario;
using ReelView.Core.Interfaces.Service; 

namespace ReelView.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public AuthController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsuarioCreateDTO dto)
        {
            try
            {
                var result = await _usuarioService.RegisterAsync(dto);
                return CreatedAtAction(nameof(Register), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO dto)
        {
            try
            {
                var result = await _usuarioService.LoginAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}