using BlackJackGameCheckerMicroservice.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackJackGameCheckerMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlackJackGameController : Controller
    {
        [HttpPost]
        public IActionResult CalculateWinner([FromBody] BlackJack blackJack)
        {
            if(blackJack == null)
            {
                throw new ArgumentNullException(nameof(blackJack));
            }

            return Ok(blackJack.DetermineWinner());
        }
    }
}
