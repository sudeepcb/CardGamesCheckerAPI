using Interfaces;

namespace BlackJackGameCheckerMicroservice.Models
{
    public class BlackJackDeck : IDeck
    {
        public int TotalCards { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IPlayer> Player { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
