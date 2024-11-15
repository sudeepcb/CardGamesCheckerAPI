using Interfaces;
using Microsoft.AspNetCore.Mvc;
using PokerGameCheckerMicroservice.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Net;
using System.Runtime.CompilerServices;

namespace PokerGameCheckerMicroservice.Controllers
{
    /// <summary>
    /// API For Checking who the winner if of the Poker Game
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PokerGameController : Controller
    {

        ///<summary>
        /// ## Straight Flush - isFlush: true, isStraight: true
        /// ## Four of a Kind - nKinds: 4
        /// ## Full House - nKinds: 3, isPair: True
        /// ## Flush - isFlush: true
        /// ## Straight - isStraight: true
        /// ## Three of a Kind - nKinds: 3
        /// ## Pair - isPair
        ///</summary>
        /// <param name="totalPlayers">Total # of players</param>
        /// <param name="isFlush">All Same SUITS ex:Hearts</param>
        /// <param name="isStraight">All Same RANKS ex:2-10/JKQA</param>
        /// <param name="nKinds">N </param>
        /// <param name="isUniqueCards">Total # of players</param>
        /// <param name="isRandom">Total # of players</param>
        /// <returns>A poker game</returns>
        [SwaggerResponse(200, "Poker Game Data", typeof(Poker))]
        [SwaggerResponse(404, Type = typeof(NotFoundResult))]
        [Route("GeneratePokerData")]
        [HttpGet]
        public IActionResult GeneratePokerData([FromQuery] int totalPlayers, [FromQuery] bool isFlush, [FromQuery] bool isStraight, [FromQuery] int nKinds, [FromQuery] bool isUniqueCards, [FromQuery] bool isRandom) 
        {
            return Ok(CardConstants.GeneratePokerData(totalPlayers, isFlush, isStraight, nKinds, isUniqueCards, isRandom));
        }
        

        /// <summary>
        /// Winner of Poker Game
        /// </summary>
        /// <param name="poker">The Poker Data of Each Player</param>
        /// <returns>The Winner poker player (Poker Player)</returns>
        [SwaggerResponse(200, "Poker Game Winner", typeof(PokerPlayer))]
        [SwaggerResponse(404, Type = typeof(NotFoundResult))]
        [HttpPost]
        [Route("CalculateWinner")]
        public IActionResult CalculateWinner([FromBody] Poker poker)
        {
            return Ok(poker.DetermineWinner());
        }
    }
}
