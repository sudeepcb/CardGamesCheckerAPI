using FluentAssertions;
using PokerGameCheckerMicroservice.Models;

namespace CardGameMicroservicesTest.Models;

public class HandTests
{
    [Theory]
    [InlineData("3S 4H 5D 6S 7H", "3S")]
    [InlineData("3S 4H 5D 6S 7H", "5D")]
    [InlineData("3S 7H 5D AS 8H", "AS")]
    [InlineData("3S 7H 5D AS 9H", "7H")]
    public void CreateHand(string input, string cardContained)
    {
        var hand = Hand.From(input);
        hand.Cards.Should().Contain(Card.From(cardContained));
    }

    [Theory]
    [InlineData("3S 4H 5D 6S 7H 8D")]
    [InlineData("3S 4H 5D 6S")]
    [InlineData("3S 7H 5D")]
    [InlineData("3S 5D 5D 5D 5D")]
    public void BadHands(string input)
    {
        var action = () => Hand.From(input);
        action.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("3S 4H 6D 8S 9H", HandRank.HighCard, 
        new[] { Rank.Nine, Rank.Eight })]
    [InlineData("KS KH 6D 8S 9H", HandRank.Pair, 
        new[] { Rank.King, Rank.Nine })]
    [InlineData("KS KH 6D 8S 8H", HandRank.TwoPairs, 
        new[] { Rank.King, Rank.Eight, Rank.Six })]
    [InlineData("KS KH KD 8S 9H", HandRank.ThreeOfAKind, 
        new[] { Rank.King, Rank.Nine })]
    [InlineData("3S 4H 5D 6S 7H", HandRank.Straight, 
        new[] { Rank.Seven })]
    [InlineData("KS QS 6S 8S 9S", HandRank.Flush, 
        new[] { Rank.King, Rank.Queen, Rank.Nine, Rank.Eight, Rank.Six })]
    [InlineData("KS KH 6D 6S 6H", HandRank.FullHouse, 
        new[] { Rank.Six, Rank.King })]
    [InlineData("KS KH KD KC 9H", HandRank.FourOfAKind, 
        new[] { Rank.King, Rank.Nine })]
    [InlineData("3S 4S 5S 6S 7S", HandRank.StraightFlush, 
        new[] { Rank.Seven })]
    [InlineData("10H JH QH KH AH", HandRank.RoyalFlush, 
        null)]
    public void EvaluateHands(string input, HandRank rank, Rank[]? strength)
    {
        var hand = Hand.From(input);
        hand.Evaluate().HandRank.Should().Be(rank);
        if (strength is not null)
        {
            hand.Evaluate().Strength.Should().BeEquivalentTo(strength);    
        }
    }
}