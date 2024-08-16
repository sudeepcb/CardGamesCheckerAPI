namespace PokerGameCheckerMicroservice.Models.External;

/// <summary>
/// Represents a Poker game.
/// </summary>
/// <param name="TotalPlayers">the total number of players in the Poker game.</param>
/// <param name="AllDecks">deck for the current game.</param>
public record Poker(
    int TotalPlayers, 
    PokerDeck AllDecks)
{
    /// <summary>
    /// Convert from internal model to external
    /// </summary>
    /// <param name="poker">internal model</param>
    /// <returns>external model</returns>
    public static Poker From(Models.Poker poker)
    {
        return new Poker(poker.TotalPlayers, PokerDeck.From(poker.AllDecks));
    }
}

/// <summary>
/// Represents a deck of cards for a Poker game.
/// </summary>
/// <param name="Players">list of players using this deck.</param>
/// <param name="TotalCards">the total number of cards in the deck.</param>
/// <param name="HighestRanked">the highest ranked player</param>

// We still want to have these properties in JSON output of our API
// ReSharper disable once NotAccessedPositionalProperty.Global
public record PokerDeck(IEnumerable<Player> Players, int TotalCards, Player? HighestRanked)
{
    /// <summary>
    /// Convert from internal model to external
    /// </summary>
    /// <param name="allDecks">internal model</param>
    /// <returns>external model</returns>
    public static PokerDeck From(Models.PokerDeck allDecks)
    {
        return new PokerDeck(allDecks.Player.Select(Player.From).OfType<Player>(),
            allDecks.TotalCards,
            Player.From(allDecks.HighestRanked));
    }
}

/// <summary>
/// Represents a player in a Poker game.
/// </summary>
/// <param name="Name">the name of the player.</param>
/// <param name="CardsInHand">an array of cards in the player's hand.</param>
/// <param name="CardRank">the player's card rank.</param>
public record Player(string Name, string[] CardsInHand, int CardRank)
{
    /// <summary>
    /// Convert from internal model to external
    /// </summary>
    /// <param name="player">internal model</param>
    /// <returns>external model</returns>
    public static Player? From(PokerPlayer? player)
    {
        return player is not null
            ? new Player(player.Name, player.CardsInHand, player.CardRank)
            : null;
    }
}