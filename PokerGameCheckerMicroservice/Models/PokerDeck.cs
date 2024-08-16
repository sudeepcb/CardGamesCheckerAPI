namespace PokerGameCheckerMicroservice.Models
{
    /// <summary>
    /// Represents a deck of cards for a Poker game.
    /// </summary>
    public class PokerDeck
    {
        private List<PokerPlayer>? _players;

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

        /// <summary>
        /// Gets or sets the total number of cards in the deck.
        /// </summary>
        public int TotalCards => 52;

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

        /// <summary>
        /// Convert external model to internal model
        /// </summary>
        /// <param name="allDecks">external model </param>
        /// <returns>internal model</returns>
        public static PokerDeck From(External.PokerDeck allDecks)
        {
            return new PokerDeck
            {
                HighestRanked = PokerPlayer.From(allDecks.HighestRanked),
                Player = allDecks.Players.Select(PokerPlayer.From).OfType<PokerPlayer>().ToList()
            };
        }
    }
}
