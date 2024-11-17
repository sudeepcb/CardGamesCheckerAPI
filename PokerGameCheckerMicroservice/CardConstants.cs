using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Microsoft.VisualBasic;
using PokerGameCheckerMicroservice.Models;

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
        public static readonly string RANKS = "23456789TJQKA";
        /// <summary>
        /// Club, Diamond, Heart, Spades
        /// </summary>
        public static readonly string SUITS = "♠♥♦♣";
        /// <summary>
        /// Card Hand Ranks
        /// </summary>
        public static readonly string[] pokerCardRanks = ["Straight Flush", "Straight", "FourKind", "ThreeKind", "TwoKind", "OneKind", "HighCard"];
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
            var sortedRanks = ranks.OrderBy(rank => RANKS.IndexOf(rank));
            var getIndex = sortedRanks.Select((rank, index) => RANKS.IndexOf(rank)).ToArray();
            bool isStraight = getIndex.SequenceEqual(getIndex); 
            //rank card in dictionary to counts of each card for checking pairs,and kinds
            var rankCounts = ranks.GroupBy(rank => rank).ToDictionary(group => group.Key, group => group.Count());
            var pair = rankCounts.Any(pair => pair.Value == 2);
            var threeOfAKind = rankCounts.Any(pair => pair.Value == 3);
            var fourOfAKind = rankCounts.Any(pair => pair.Value == 4);

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
        public static Poker GeneratePokerData(int totalPlayers, bool isFlush, bool isStraight, int nKinds, bool isDistinct, bool isRandom)
        {
            Poker poker = new Poker()!;
            Func<bool,bool,int,bool, PokerPlayer> executeGenerator = GeneratePokerPlayerWithCards;
            List<PokerPlayer> pokerPlayers = new List<PokerPlayer>()!;
            
            poker.TotalPlayers = totalPlayers;
            foreach(int index in Enumerable.Range(0, totalPlayers))
            {
                if(isRandom && (isFlush == false || isStraight == false || nKinds == 0 || isDistinct == false))
                {
                    if(pokerCardRanks[new Random().Next(0,pokerCardRanks.Length - 1)] == "Straight Flush")
                    {
                        pokerPlayers.Add(executeGenerator(true, true, 0, false));
                    }
                    
                    if(pokerCardRanks[new Random().Next(0,pokerCardRanks.Length - 1)] == "Straight")
                    {
                        pokerPlayers.Add(executeGenerator(true, false, 0, false));
                    }

                    if(pokerCardRanks[new Random().Next(0,pokerCardRanks.Length - 1)] == "FourKind")
                    {
                        pokerPlayers.Add(executeGenerator(false, false, 4, false));
                    }

                    if(pokerCardRanks[new Random().Next(0,pokerCardRanks.Length - 1)] == "ThreeKind")
                    {
                        pokerPlayers.Add(executeGenerator(false, false, 3, false));
                    }

                    if(pokerCardRanks[new Random().Next(0,pokerCardRanks.Length - 1)] == "Two Kind")
                    {
                        pokerPlayers.Add(executeGenerator(false, false, 2, false));
                    }

                    if(pokerCardRanks[new Random().Next(0,pokerCardRanks.Length - 1)] == "oneKind")
                    {
                        pokerPlayers.Add(executeGenerator(false, false, 1, false));
                    }

                    if(pokerCardRanks[new Random().Next(0,pokerCardRanks.Length - 1)] == "HighCard")
                    {
                        pokerPlayers.Add(executeGenerator(false, false, 0, true));
                    }
                }
                pokerPlayers.Add(executeGenerator(isStraight, isFlush, nKinds, isDistinct));
            }
            poker.AllDecks = new PokerDeck
            {
                Player = pokerPlayers,
                TotalCards = 52,
            };

            return poker;
        }


        /// <summary>
        /// Generate specific poker hands
        /// </summary>
        public static PokerPlayer GeneratePokerPlayerWithCards(bool isStraight, bool isFlush, int nKinds, bool isDistinct)
        {
            string[] names = ["Hearts", "Spades", "Diamond", "Spade", "Ace"];
            Random random = new Random();
            PokerPlayer pokerPlayer = new PokerPlayer();
            var data = RANKS.Length - 1;
            string pairsRanks = String.Format("{0}{1}", RANKS[random.Next(0, random.Next(0, RANKS.Length - 1))], SUITS[random.Next(0,SUITS.Length - 1)]);
            char rank = RANKS[random.Next(0,RANKS.Length)];
            char suits = SUITS[random.Next(0,SUITS.Length)];
            int[] randomUniqueNums = randomUniqueNumsGenerator();
            

            if(isStraight && isFlush)
            {
                pokerPlayer.cardsInHand = new string[5]
                {
                    pairsRanks,
                    pairsRanks,
                    pairsRanks,
                    pairsRanks,
                    pairsRanks
                };
            }   

            if(isStraight && pokerPlayer.cardsInHand == null)
            {
                pokerPlayer.cardsInHand = new string[5]
                {
                    String.Format("{0}{1}", rank + SUITS[randomUniqueNums[0]]),
                    String.Format("{0}{1}", rank + SUITS[randomUniqueNums[1]]),
                    String.Format("{0}{1}", rank + SUITS[randomUniqueNums[2]]),
                    String.Format("{0}{1}", rank + SUITS[randomUniqueNums[3]]),
                    String.Format("{0}{1}", rank + SUITS[randomUniqueNums[4]])
                };
            }

            if(isDistinct && pokerPlayer.cardsInHand != null)
            {
                pokerPlayer.cardsInHand = new string[5]
                {
                    String.Format("{0}{1}", RANKS[randomUniqueNums[0]] + SUITS[randomUniqueNums[0]]),
                    String.Format("{0}{1}", RANKS[randomUniqueNums[0]] + SUITS[randomUniqueNums[1]]),
                    String.Format("{0}{1}", RANKS[randomUniqueNums[0]] + SUITS[randomUniqueNums[2]]),
                    String.Format("{0}{1}", RANKS[randomUniqueNums[0]] + SUITS[randomUniqueNums[3]]),
                    String.Format("{0}{1}", RANKS[randomUniqueNums[0]] + SUITS[randomUniqueNums[4]])
                };
            }

            if(nKinds > 0)
            {
                string[] nPairs = new string[5];
                foreach (int i in Enumerable.Range(0,nKinds - 1))
                {
                    nPairs[i] = String.Format("{0}{1}", rank, suits);
                }

                foreach(int i in Enumerable.Range(nKinds, 5))
                {
                    nPairs[i] = String.Format("{0}{1}", RANKS[randomUniqueNums[0]] + SUITS[randomUniqueNums[1]]);
                }
            }
            
            return pokerPlayer;
        }

        private static int[] randomUniqueNumsGenerator()
        {
            int[] randomUniqueNums = new int[5];
            while(randomUniqueNums.Length < 5)
            {
                var randomSeed = new Random().Next(0,13);
                var numsExists = randomUniqueNums.Contains(randomSeed);
                var i = 0;
                if(!numsExists)
                {
                    randomUniqueNums[i] = randomSeed;
                    i++;
                }   
            }

            return randomUniqueNums;
        }
    }
}
