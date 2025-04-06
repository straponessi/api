using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BankController : Controller
    {
        private readonly BankService _bankService;

        public BankController(BankService bankService)
        {
            _bankService = bankService;
        }

        [HttpPost("{playerId:long}/deposit")]
        public async Task<IActionResult> Deposit(long playerId, [FromBody] long amount)
        {
            await _bankService.DepositAsync(playerId, amount);
            return Ok();
        }

        [HttpPost("{playerId:long}/withdraw")]
        public async Task<IActionResult> Withdraw(long playerId, [FromBody] long amount)
        {
            try
            {
                await _bankService.WithdrawAsync(playerId, amount);
                return Ok();
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{playerId:long}/balance")]
        public async Task<IActionResult> GetBalance(long playerId)
        {
            var balance = await _bankService.GetBalanceAsync(playerId);
            return Ok(balance);
        }
    }
}
