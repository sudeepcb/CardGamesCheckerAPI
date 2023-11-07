using Interfaces;

namespace PokerGameCheckerMicroservice.Models
{
    /// <summary>
    /// Represents a deck of cards for a Poker game.
    /// </summary>
    public class PokerDeck
    {
        private List<PokerPlayer> _players = null!;

        /// <summary>
        /// Gets or sets a list of players using this deck.
        /// </summary>
        public List<PokerPlayer> Player
        {
            get
            {
                return _players;
            }

            set
            {
                if (value.Count > 1)
                {
                    _players = value;
                }
                else
                {
                    throw new ArgumentNullException("Players must be more than 1 to play a game");
                }
            }
        }

        private int _totalCards;

        /// <summary>
        /// Gets or sets the total number of cards in the deck.
        /// </summary>
        public int TotalCards
        {
            get
            {
                return _totalCards;
            }
            set
            {
                if (value >= _players.Count * 5)
                {
                    _totalCards = value;
                }
                else
                {
                    throw new ArgumentNullException("Total Cards must be greater or equal to the number of Players times 5");
                }
            }
        }

        /// <summary>
        /// Constructor for Poker Deck Class
        /// </summary>
        public PokerDeck()
        {

        }
    }
}
