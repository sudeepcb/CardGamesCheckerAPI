namespace Interfaces
{
    public interface IPlayer
    {
        string Name { get; set;  }

        string[] cardsInHand { get; set; }

        int CardRank { get; set; }

    }
}