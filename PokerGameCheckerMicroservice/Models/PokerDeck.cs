using Interfaces;

namespace PokerGameCheckerMicroservice.Models
{
    /// <summary>
    /// Represents a deck of cards for a Poker game.
    /// </summary>
    public class PokerDeck
    {
        private List<PokerPlayer>? _players = null!;

        /// <summary>
        /// Gets or sets a list of players using this deck.
        /// </summary>
        public List<PokerPlayer> Player
        {
            get
            {
                return _players ?? new List<PokerPlayer>();
            }

            set
            {
                _players = value;
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
                _totalCards = 52;
            }
        }

        private PokerPlayer? _highestRanked;

        /// <summary>
        /// Get or sets the highest ranked player
        /// </summary>
        public PokerPlayer? HighestRanked 
        {
            get
            {
                return _highestRanked;
            } 
            set
            {
                _highestRanked = value;
            }
        }

        /// <summary>
        /// Constructor for Poker Deck Class
        /// </summary>
        public PokerDeck()
        {

        }

        public static PokerDeck From(External.PokerDeck allDecks)
        {
            return new PokerDeck
            {
                TotalCards = allDecks.TotalCards,
                HighestRanked = PokerPlayer.From(allDecks.HighestRanked),
                Player = allDecks.Players.Select(PokerPlayer.From).OfType<PokerPlayer>().ToList()
            };
        }
    }
}
