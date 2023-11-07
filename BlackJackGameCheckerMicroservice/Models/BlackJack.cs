using Interfaces;

namespace BlackJackGameCheckerMicroservice.Models
{
    public class BlackJack : ICardGame
    {
        public int TotalPlayers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IDeck> AllDecks { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public BlackJack(BlackJack blackJack)
        {
            TotalPlayers = blackJack.TotalPlayers;
            AllDecks = blackJack.AllDecks;
        }
        public IPlayer DetermineWinner()
        {
            return new BlackJackPlayer();
        }
    }
}
