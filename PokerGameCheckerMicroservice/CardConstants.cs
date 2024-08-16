﻿using PokerGameCheckerMicroservice.Models;

namespace PokerGameCheckerMicroservice
{
    /// <summary>
    /// A static class that defines constants and methods for working with poker cards.
    /// </summary>
    public static class CardConstants
    {
        // Constants for Ranks and Suits of Poker Cards
        /// <summary>
        /// Cards in a Typical Poker Game
        /// </summary>
        public static readonly string Ranks = "23456789TJQKA";
        /// <summary>
        /// Club, Diamond, Heart, Spades
        /// </summary>
        public static readonly string Suits = "♠♥♦♣";

        /// <summary>
        /// Evaluates a poker hand and determines its ranking.
        /// </summary>
        /// <param name="hands">An array of poker cards in the player's hand.</param>
        /// <returns>The rank of the poker hand.</returns>
        public static int EvaluateHand(string[] hands)
        {
            var ranks = hands.Select(card => card[0]).ToArray();
            var suits = hands.Select(card => card[1]).ToArray();

            //check for flush (all cards have the same suits)
            var isFlush = suits.All(s => s == suits[0]);

            //check for straight (consecutive ranks)
            var sortedRanks = ranks.OrderBy(rank => Ranks.IndexOf(rank));
            var getIndex = sortedRanks.Select((rank, _) => Ranks.IndexOf(rank)).ToArray();
            bool isStraight = getIndex.SequenceEqual(getIndex); 
            //rank card in dictionary to counts of each card for checking pairs,and kinds
            var rankCounts = ranks.GroupBy(rank => rank).ToDictionary(group => group.Key, group => group.Count());
            var pair = rankCounts.Any(pair => pair.Value == 2);
            var threeOfAKind = rankCounts.Any(p => p.Value == 3);
            var fourOfAKind = rankCounts.Any(p => p.Value == 4);

            // Determine the rank of the hand
            if (isFlush && isStraight)
                return 9; // Straight Flush
            if (fourOfAKind)
                return 8; // Four of a Kind
            if (pair && threeOfAKind)
                return 7; // Full House
            if (isFlush)
                return 6; // Flush
            if (isStraight)
               return 5; // Straight
            if (threeOfAKind)
                return 4; // Three of a Kind
            if (pair)
                return 3; // Two Pair
            if (rankCounts.Count == 4 && pair)
                return 2; // One Pair (2 pairs)
            if (pair)
                return 1; // One Pair
            return 0; // High Card
        }

        ///<summary>
        ///Generates data for a poker game
        ///</summary>
        public static Poker GeneratePokerData(int totalPlayers)
        {
            Poker poker;
            var random = new Random();

            string[] names = ["Heart", "Spade", "Diamond", "Club", "Ace"];
            List<PokerPlayer> generatedPlayers = Enumerable.Range(0, totalPlayers).Select(_ => new PokerPlayer
            {
                Name = names[random.Next(0, names.Length)],
                CardsInHand = new string[5]
                {
                    String.Format("{0}{1}", Ranks[random.Next(0, Ranks.Length)], Suits[random.Next(0, Suits.Length)]),
                    String.Format("{0}{1}", Ranks[random.Next(0, Ranks.Length)], Suits[random.Next(0, Suits.Length)]),
                    String.Format("{0}{1}", Ranks[random.Next(0, Ranks.Length)], Suits[random.Next(0, Suits.Length)]),
                    String.Format("{0}{1}", Ranks[random.Next(0, Ranks.Length)], Suits[random.Next(0, Suits.Length)]),
                    String.Format("{0}{1}", Ranks[random.Next(0, Ranks.Length)], Suits[random.Next(0, Suits.Length)]),
                },
                CardRank = 0
            }).ToList();

            poker = new Poker
            {
                TotalPlayers = totalPlayers,
                AllDecks = new PokerDeck
                {
                    Player = generatedPlayers
                }
            };

            return poker;
        }
    }
}
