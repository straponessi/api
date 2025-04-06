using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly UserService _userService;

        public PlayersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] string name)
        {
            var player = await _userService.CreatePlayerAsync(name);
            return Ok(player);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetPlayer(long id)
        {
            var player = await _userService.GetPlayerAsync(id);
            if (player == null) return NotFound();
            return Ok(player);
        }
    }
}
