using Interfaces;
using Microsoft.AspNetCore.Mvc;
using PokerGameCheckerMicroservice.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Net;

namespace PokerGameCheckerMicroservice.Controllers
{
    /// <summary>
    /// API For Checking who the winner if of the Poker Game
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PokerGameController : Controller
    {
        /// <summary>
        /// Returns Winner of Poker Game
        /// </summary>
        /// <param name="poker">The Poker Data of Each Player</param>
        /// <returns>The Winner poker player (Poker Player)</returns>
        [SwaggerResponse(200, "Poker Game Winner", typeof(PokerPlayer))]
        [SwaggerResponse(404, Type = typeof(NotFoundResult))]
        [HttpPost]
        public IActionResult CalculateWinner([FromBody] Poker poker)
        {
            return Ok(poker.DetermineWinner());
        }
    }
}
