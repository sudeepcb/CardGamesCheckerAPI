using Interfaces;
using PokerGameCheckerMicroservice;
using PokerGameCheckerMicroservice.Models;
using System;
using System.Collections.Generic;

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
            if (value > 0)
            {
                _players = value;
            }
            else
            {
                throw new ArgumentNullException("MyProperty cannot be set to null");
            }
        }
    }

    private PokerDeck _decksInHand = null!;

    /// <summary>
    /// Gets or sets deck for the current game.
    /// </summary>
    public PokerDeck AllDecks
    {
        get { return _decksInHand; }
        set
        {
            if (value != null)
            {
                _decksInHand = value;
            }
            else
            {
                throw new ArgumentNullException("MyProperty cannot be set to null");
            }
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
    public PokerPlayer DetermineWinner()
    {
        PokerPlayer highestRankedPlayer = null!;
        if (_decksInHand.Player.Count != _players)
        {
            throw new ArgumentNullException("Total Players does not match Decks of Players");
        }

        foreach (var players in _decksInHand.Player)
        {
            var rank = CardConstants.EvaluateHand(players.cardsInHand);
            players.CardRank = rank;

            if (highestRankedPlayer == null)
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
            }
        }
        return highestRankedPlayer;
    }
}
