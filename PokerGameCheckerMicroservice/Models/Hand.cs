using CardGameMicroservicesTest.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace PokerGameCheckerMicroservice.Models;

public record Hand
{
    public Hand(IEnumerable<Card> cards)
    {
        Cards = cards.ToList();
        if (Cards.Distinct().Count() != 5)
        {
            throw new ArgumentException(nameof(cards));
        }
    }
    
    public static Hand From(string cards) => 
        new(cards.Split(" ").Select(Card.From));

    public IEnumerable<Card> Cards { get; }

    public Ranking Evaluate()
    {
        var byRank = Cards.GroupBy(c => c.Rank).ToList();
        var bySuit = Cards.GroupBy(c => c.Suit).ToList();
        var ordered = Cards.OrderBy(c => c.Rank).ToList();
        HandRank handRank;
        IEnumerable<Rank> strength;
        if (IsRoyalFlush(byRank, bySuit, ordered))
        {
            handRank = HandRank.RoyalFlush;
            strength = [];
        }
        else if (IsStraightFlush(byRank, bySuit, ordered))
        {
            handRank = HandRank.StraightFlush;
            strength = [ordered.Last().Rank];
        }
        else if (IsStraight(byRank, ordered))
        {
            handRank = HandRank.Straight;
            strength = [ordered.Last().Rank];
        }
        else if (IsFlush(bySuit))
        {
            handRank = HandRank.Flush;
            strength = ordered.Select(c => c.Rank).Reverse();
        }
        else if (IsFourOfAKind(byRank))
        {
            handRank = HandRank.FourOfAKind;
            strength = [byRank.First(g => g.Count() == 4).First().Rank,
                byRank.First(g => g.Count() == 1).First().Rank];
        }
        else if (IsFullHouse(byRank))
        {
            handRank = HandRank.FullHouse;
            strength = [byRank.First(g => g.Count() == 3).First().Rank,
                byRank.First(g => g.Count() == 2).First().Rank];
        }
        else if (IsThreeOfAKind(byRank))
        {
            handRank = HandRank.ThreeOfAKind;
            strength = byRank.Where(g => g.Count() == 3).Select(g => g.Select(c => c.Rank).Max())
                .Append(byRank.Where(g => g.Count() == 1).SelectMany(g => g.Select(c => c.Rank)).Max());
        }
        else if (IsTwoPairs(byRank))
        {
            handRank = HandRank.TwoPairs;
            strength = byRank.Where(g => g.Count() == 2).Select(g => g.First().Rank).OrderDescending()
                .Append(byRank.First(g => g.Count() == 1).First().Rank);
        }
        else if (IsPair(byRank))
        {
            handRank = HandRank.Pair;
            strength = [byRank.First(g => g.Count() == 2).First().Rank,
                byRank.Where(g => g.Count() == 1).SelectMany(g => g.Select(c => c.Rank)).Max()];
        }
        else
        {
            handRank = HandRank.HighCard;
            strength = [ordered.Last().Rank, ordered.Skip(3).First().Rank];
        }
        return new Ranking(handRank, strength);
    }

    private static bool IsPair(List<IGrouping<Rank, Card>> byRank) => 
        byRank.Any(g => g.Count() == 2);

    private static bool IsTwoPairs(List<IGrouping<Rank, Card>> byRank) => 
        byRank.Count(g => g.Count() == 2) == 2;

    private static bool IsThreeOfAKind(List<IGrouping<Rank, Card>> byRank) => 
        byRank.Any(g => g.Count() == 3);

    private static bool IsFullHouse(List<IGrouping<Rank, Card>> byRank) =>
        byRank.Any(g => g.Count() == 3)
        && byRank.Any(g => g.Count() == 2);

    private static bool IsFourOfAKind(List<IGrouping<Rank, Card>> byRank) => 
        byRank.Any(g => g.Count() == 4);

    private static bool IsFlush(List<IGrouping<Suit, Card>> bySuit) => 
        bySuit.Count == 1;

    private static bool IsStraight(
        List<IGrouping<Rank, Card>> byRank, List<Card> ordered) =>
        byRank.All(g => g.Count() == 1)
        && ordered.Zip(ordered.Skip(1)).All(p => (int)p.First.Rank + 1 == (int)p.Second.Rank);

    private static bool IsStraightFlush(
        List<IGrouping<Rank, Card>> byRank, List<IGrouping<Suit, Card>> bySuit, List<Card> ordered) =>
        IsStraight(byRank, ordered)
        && bySuit.Count == 1;

    private static bool IsRoyalFlush(
        List<IGrouping<Rank, Card>> byRank, List<IGrouping<Suit, Card>> bySuit, List<Card> ordered) =>
        IsStraightFlush(byRank, bySuit, ordered)
        && ordered.LastOrDefault()?.Rank == Rank.Ace;
}

public record Ranking(HandRank HandRank, IEnumerable<Rank> Strength)
{
}

public enum HandRank
{
    HighCard,
    Pair,
    TwoPairs,
    ThreeOfAKind,
    Straight,
    Flush,
    FullHouse,
    FourOfAKind,
    StraightFlush,
    RoyalFlush
}