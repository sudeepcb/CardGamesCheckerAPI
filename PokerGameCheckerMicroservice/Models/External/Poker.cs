namespace PokerGameCheckerMicroservice.Models.External;

public record Poker(int TotalPlayers, PokerDeck AllDecks)
{
    public static Poker From(Models.Poker poker)
    {
        return new Poker(poker.TotalPlayers, PokerDeck.From(poker.AllDecks));
    }
}

public record PokerDeck(IEnumerable<Player> Players, int TotalCards, Player? HighestRanked)
{
    public static PokerDeck From(Models.PokerDeck allDecks)
    {
        return new PokerDeck(allDecks.Player.Select(Player.From).OfType<Player>(),
            allDecks.TotalCards,
            Player.From(allDecks.HighestRanked));
    }
}

public record Player(string Name, string[] CardsInHand, int CardRank)
{
    public static Player? From(PokerPlayer? player)
    {
        return player is not null
            ? new Player(player.Name, player.cardsInHand, player.CardRank)
            : null;
    }
}