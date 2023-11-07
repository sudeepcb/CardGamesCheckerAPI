using Interfaces;

namespace BlackJackGameCheckerMicroservice.Models
{
    public class BlackJackPlayer : IPlayer
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string[] cardsInHand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int CardRank { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
