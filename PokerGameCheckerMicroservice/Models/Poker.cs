namespace PokerGameCheckerMicroservice.Models;

/// <summary>
/// Represents a Poker game.
/// </summary>
public class Poker
{
    private int _players;

    /// <summary>
    /// Gets or sets the total number of players in the Poker game.
    /// </summary>
    public int TotalPlayers
    {
        get { return _players; }
        set
        {
            _players = value;
        }
    }

    private PokerDeck? _decksInHand;

    /// <summary>
    /// Gets or sets deck for the current game.
    /// </summary>
    public PokerDeck AllDecks
    {
        get { return _decksInHand ?? new PokerDeck(); }
        set
        {
            _decksInHand = value;
        }
    }

    /// <summary>
    /// Constuctor for Poker Class
    /// </summary>
    public Poker()
    {

    }

    /// <summary>
    /// Determine the winner of the Poker game.
    /// </summary>
    /// <returns>The winning player.</returns>
    public PokerDeck DetermineWinner()
    {
        if (_decksInHand?.Player.Count != _players)
        {
            throw new ArgumentNullException(nameof(TotalPlayers), "Total Players does not match Decks of Players");
        }

        foreach (var players in _decksInHand.Player)
        {
            var rank = CardConstants.EvaluateHand(players.CardsInHand);
            players.CardRank = rank;

            /* if (highestRankedPlayer == null)
        {
            highestRankedPlayer = players;
        }
        else if (highestRankedPlayer.CardRank == rank)
        {
            if (players.cardsInHand.Max(card => CardConstants.RANKS.IndexOf(card[0])) > highestRankedPlayer.cardsInHand.Max(card => CardConstants.RANKS.IndexOf(card[0])))
            {
                highestRankedPlayer = players;
            }
            else if (players.cardsInHand.Max(card => CardConstants.RANKS.IndexOf(card[0])) == highestRankedPlayer.cardsInHand.Max(card => CardConstants.RANKS.IndexOf(card[0])))
            {

            }
        } */
        }
        AllDecks.HighestRanked = AllDecks.Player.OrderByDescending(x => x.CardRank).FirstOrDefault()!;
        return AllDecks;
    }

    /// <summary>
    /// Converts external model to internal model
    /// </summary>
    /// <param name="poker">external model</param>
    /// <returns>internal model</returns>
    public static Poker From(External.Poker poker)
    {
        return new Poker
        {
            TotalPlayers = poker.TotalPlayers,
            AllDecks = PokerDeck.From(poker.AllDecks)
        };
    }
}