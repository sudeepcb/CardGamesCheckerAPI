using FluentAssertions;

namespace CardGameMicroservicesTest.Models;

public class CardTests
{
    [Theory]
    [InlineData(Rank.Two, Suit.Heart, "2H")]
    [InlineData(Rank.Three, Suit.Heart, "3H")]
    [InlineData(Rank.Three, Suit.Diamond, "3D")]
    [InlineData(Rank.Jack, Suit.Diamond, "JD")]
    [InlineData(Rank.King, Suit.Diamond, "KD")]
    public void CardToString(Rank rank, Suit suit, string expected)
    {
        var card = new Card(rank, suit);
        card.ToString().Should().Be(expected);
    }
    
    [Theory]
    [InlineData(Rank.Two, Suit.Heart, "2H")]
    [InlineData(Rank.Three, Suit.Heart, "3H")]
    [InlineData(Rank.Three, Suit.Diamond, "3D")]
    [InlineData(Rank.Jack, Suit.Diamond, "JD")]
    [InlineData(Rank.King, Suit.Diamond, "KD")]
    [InlineData(Rank.Ten, Suit.Diamond, "10D")]
    public void CardFromString(Rank rank, Suit suit, string input)
    {
        var card = Card.From(input);
        card.Rank.Should().Be(rank);
        card.Suit.Should().Be(suit);
    }
    
    [Theory]
    [InlineData(Rank.Two, Suit.Heart, "2h")]
    [InlineData(Rank.Three, Suit.Heart, "3h")]
    [InlineData(Rank.Three, Suit.Diamond, "3d")]
    [InlineData(Rank.Jack, Suit.Diamond, "jd")]
    [InlineData(Rank.King, Suit.Diamond, "kd")]
    [InlineData(Rank.Ten, Suit.Diamond, "10d")]
    public void CardFromLowercaseString(Rank rank, Suit suit, string input)
    {
        var card = Card.From(input);
        card.Rank.Should().Be(rank);
        card.Suit.Should().Be(suit);
    }

    [Fact]
    public void InvalidInputForCardCreation()
    {
        var action = () => Card.From("nonsense");
        action.Should().Throw<ArgumentException>();
    } 
    
}