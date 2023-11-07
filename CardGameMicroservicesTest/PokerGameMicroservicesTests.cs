using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PokerGameCheckerMicroservice;
using PokerGameCheckerMicroservice.Controllers;
using PokerGameCheckerMicroservice.Models;

namespace CardGameMicroservicesTest
{
    public class PokerGameMicroservicesTests
    {
        private readonly IFixture _fixture;
        private readonly PokerGameController _sut;

        public PokerGameMicroservicesTests()
        {
            _fixture = new Fixture();
            _sut = new PokerGameController();
        }
        [Fact]
        public void PokerGameChecker_CalculateWinner_ReturnsIActionResult()
        {
            var pokerModel = new Poker();
            pokerModel.TotalPlayers = 2;
            var deck = new PokerDeck();
            var player1 = new PokerPlayer();
            player1.Name = "Player1";
            player1.cardsInHand = new string[5] { "3D", "4H", "5S", "6C", "7S" };
            var player2 = new PokerPlayer();
            player2.Name = "Player2";
            player2.cardsInHand = new string[5] { "3D", "3H", "5S", "6C", "7S" };
            deck.Player = new List<PokerPlayer> { player1, player2 };
            deck.TotalCards = 10;
            pokerModel.AllDecks = deck;
            var result = _sut.CalculateWinner(pokerModel);

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<IActionResult>();

        }

        /*[Fact]
        public void PokerGameChecker_CalculateWinner_ShouldThrowArgumentNullException()
        {
            var pokerModel = new Poker();
            var deck = new PokerDeck();
            var player1 = new PokerPlayer();
            player1.Name = "Player1";
            player1.cardsInHand = new string[5] { "3D", "4H", "5S", "6C", "7S" };
            var player2 = new PokerPlayer();
            player2.Name = "Player2";
            player2.cardsInHand = new string[5] { "3D", "3H", "5S", "6C", "7S" };
            deck.Player = new List<PokerPlayer> { player1, player2 };
            deck.TotalCards = 0;
            pokerModel.TotalPlayers = 2;
            pokerModel.AllDecks = deck;
            Assert.Throws<ArgumentNullException>(() => _sut.CalculateWinner(pokerModel));

        }*/
        [Fact]
        public void CardConstants_CheckIfCardRankingIsCorrectForGame_ReturnsRankWithGivenCards()
        {
            var pokerPlayer = new PokerPlayer();
            pokerPlayer.Name = "Player1";
            pokerPlayer.cardsInHand = new string[5] { "3D", "4H", "5S", "6C", "7S" };

            var result = CardConstants.EvaluateHand(pokerPlayer.cardsInHand);

            result.Should().BeGreaterThanOrEqualTo(0);

            result.Should().BeOfType(typeof(int));
        }
    }
}