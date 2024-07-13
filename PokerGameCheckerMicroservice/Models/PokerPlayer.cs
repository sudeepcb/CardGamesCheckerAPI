using Interfaces;
using System;
using System.Linq;

/// <summary>
/// Represents a player in a Poker game.
/// </summary>
public class PokerPlayer : IPlayer
{
    private string? _name;

    /// <summary>
    /// Gets or sets the name of the player.
    /// </summary>
    public string Name
    {
        get
        {
            return _name ?? "";
        }
        set
        {
          _name = value;
        }
    }

    private string[]? _cardsInHand = null;

    /// <summary>
    /// Gets or sets an array of cards in the player's hand.
    /// </summary>
    public string[] cardsInHand
    {
        get
        {
            return _cardsInHand ?? new string[5];
        }
        set
        {
            if(value != null){
                
                var isValid = value.All(c => c.Length == 2);
                if (isValid && (value.Length > 3 && value.Length < 6))
                {
                    _cardsInHand = value;
                }
                else
                {
                    throw new ArgumentNullException("Cards must have rank and suits defined and must have at least 3 cards and no more than 5");
                }
            }
        }

    }

    private int _rank;

    /// <summary>
    /// Gets or sets the player's card rank.
    /// </summary>
    public int CardRank
    {
        get
        {
            return _rank;
        }
        set
        {
            _rank = value;
        }
    }

    /// <summary>
    /// Constructor for Poker Player Class
    /// </summary>
    public PokerPlayer()
    {

    }
}
