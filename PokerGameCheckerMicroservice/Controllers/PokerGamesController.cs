using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System.Net;
using System.Runtime.CompilerServices;
using PokerGameCheckerMicroservice.Models.External;

namespace PokerGameCheckerMicroservice.Controllers
{
    /// <summary>
    /// API For Checking who the winner if of the Poker Game
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PokerGamesController : Controller
    {

        ///<summary>
        /// Generates a poker data based on n cards
        ///</summary>
        /// <param name="totalPlayers">Total # of players</param>
        /// <returns>A poker game</returns>
        [SwaggerResponse(200, "Poker Game Data", typeof(Models.External.Poker))]
        [HttpGet("pokerdata")]
        public IActionResult GeneratePokerData([FromQuery] int totalPlayers)
        {
            return Ok(Models.External.Poker.From(CardConstants.GeneratePokerData(totalPlayers)));
        }
        
        ///<summary>
        /// Generates a straight flush poker data based on n cards
        ///</summary>
        /// <param name="totalPlayers">Total # of players</param>
        /// <returns>A poker game</returns>
        [SwaggerResponse(200, "Poker Game Data", typeof(Models.External.Poker))]
        [HttpGet("straightflush")]
        public IActionResult GenerateStraightFlush([FromQuery] int totalPlayers)
        {
            return Ok();
        }
        
        ///<summary>
        /// Generates a four of a kind poker data based on n cards
        ///</summary>
        /// <param name="totalPlayers">Total # of players</param>
        /// <returns>A poker game</returns>
        [SwaggerResponse(200, "Poker Game Data", typeof(Models.External.Poker))]
        [HttpGet("fourofakind")]
        public IActionResult GenerateFourOfAKind([FromQuery] int totalPlayers)
        {
            return Ok();
        }
        
        ///<summary>
        /// Generates a full house poker data based on n cards
        ///</summary>
        /// <param name="totalPlayers">Total # of players</param>
        /// <returns>A poker game</returns>
        [SwaggerResponse(200, "Poker Game Data", typeof(Models.External.Poker))]
        [HttpGet("fullhouse")]
          public IActionResult GenerateFullHouse([FromQuery] int totalPlayers)
        {
            return Ok();
        }
        
        ///<summary>
        /// Generates a flush poker data based on n cards
        ///</summary>
        /// <param name="totalPlayers">Total # of players</param>
        /// <returns>A poker game</returns>
        [SwaggerResponse(200, "Poker Game Data", typeof(Models.External.Poker))]
        [HttpGet("flush")]
           public IActionResult GenerateFlush([FromQuery] int totalPlayers)
        {
            return Ok();
        }
        
        ///<summary>
        /// Generates a straight poker data based on n cards
        ///</summary>
        /// <param name="totalPlayers">Total # of players</param>
        /// <returns>A poker game</returns>
        [SwaggerResponse(200, "Poker Game Data", typeof(Models.External.Poker))]
        [HttpGet("straight")]
        public IActionResult GenerateStraight([FromQuery] int totalPlayers)
        {
            return Ok();
        }
        
        ///<summary>
        /// Generates a three of a kind poker data based on n cards
        ///</summary>
        /// <param name="totalPlayers">Total # of players</param>
        /// <returns>A poker game</returns>
        [SwaggerResponse(200, "Poker Game Data", typeof(Models.External.Poker))]
        [HttpGet("threeofakind")]
          public IActionResult GenerateThreeOfAKind([FromQuery] int totalPlayers)
        {
            return Ok();
        }
        
        ///<summary>
        /// Generates a two pair poker data based on n cards
        ///</summary>
        /// <param name="totalPlayers">Total # of players</param>
        /// <returns>A poker game</returns>
        [SwaggerResponse(200, "Poker Game Data", typeof(Models.External.Poker))]
        [HttpGet("twopair")]
           public IActionResult GenerateTwoPair([FromQuery] int totalPlayers)
        {
            return Ok();
        }
        
        ///<summary>
        /// Generates a one pair poker data based on n cards
        ///</summary>
        /// <param name="totalPlayers">Total # of players</param>
        /// <returns>A poker game</returns>
        [SwaggerResponse(200, "Poker Game Data", typeof(Models.External.Poker))]
        [HttpGet("onepair")]
        public IActionResult GenerateOnePair([FromQuery] int totalPlayers)
        {
            return Ok();
        }
        
        ///<summary>
        /// Generates a high card poker data based on n cards
        ///</summary>
        /// <param name="totalPlayers">Total # of players</param>
        /// <returns>A poker game</returns>
        [SwaggerResponse(200, "Poker Game Data", typeof(Models.External.Poker))]
        [HttpGet("highcard")]
          public IActionResult GenerateHighCard([FromQuery] int totalPlayers)
        {
            return Ok();
        }

        /// <summary>
        /// Winner of Poker Game
        /// </summary>
        /// <param name="poker">The Poker Data of Each Player</param>
        /// <returns>The Winner poker player (Poker Player)</returns>
        [SwaggerResponse(200, "Poker Game Winner", typeof(Player))]
        [HttpPost]
        public IActionResult CalculateWinner([FromBody] Poker poker)
        {
            return Ok(PokerDeck.From(Models.Poker.From(poker).DetermineWinner()));
        }
    }
}
