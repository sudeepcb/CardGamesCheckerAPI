using System.ComponentModel;
using Microsoft.OpenApi.Extensions;

namespace CardGameMicroservicesTest.Models;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public enum Rank
{
    [Description("2")] Two,
    [Description("3")] Three,
    [Description("4")] Four,
    [Description("5")] Five,
    [Description("6")] Six,
    [Description("7")] Seven,
    [Description("8")] Eight,
    [Description("9")] Nine,
    [Description("10")] Ten,
    [Description("J")] Jack,
    [Description("Q")] Queen,
    [Description("K")] King,
    [Description("A")] Ace
}

public enum Suit
{
    [Description("H")] Heart,
    [Description("D")] Diamond,
    [Description("C")] Club,
    [Description("S")] Spade
}

public record Card(Rank Rank, Suit Suit)
{
    public override string ToString()
    {
        return Rank.GetAttributeOfType<DescriptionAttribute>().Description
               + Suit.GetAttributeOfType<DescriptionAttribute>().Description;
    }

    public static Card From(string input)
    {
        var rank = Enum.GetValues<Rank>()
            .FirstOrDefault(s =>
                input.StartsWith(s.GetAttributeOfType<DescriptionAttribute>().Description, StringComparison.OrdinalIgnoreCase));
        var suit = Enum.GetValues<Suit>()
            .FirstOrDefault(s =>
                input.EndsWith(s.GetAttributeOfType<DescriptionAttribute>().Description, StringComparison.OrdinalIgnoreCase));
        // nulls would default to 0 enums
        if (rank == 0 && !input.StartsWith("2")
            || (suit == 0 && !input.EndsWith("H", StringComparison.OrdinalIgnoreCase)))
        {
            throw new ArgumentException(nameof(input));
        }
        return new Card(rank, suit);
    }
}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member