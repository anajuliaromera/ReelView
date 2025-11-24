using Microsoft.AspNetCore.Mvc;
using ReelView.Core.Interfaces;
using ReelView.Core.Interfaces.Service;

namespace ReelView.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RankingController : ControllerBase
    {
        private readonly IRankingService _service;

        public RankingController(IRankingService service)
        {
            _service = service;
        }

        [HttpGet("top10")]
        public async Task<IActionResult> GetTop10() => Ok(await _service.GetTop10Async());
    }
}
