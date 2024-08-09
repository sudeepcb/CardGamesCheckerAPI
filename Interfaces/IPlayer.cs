namespace Interfaces
{
    public interface IPlayer
    {
        string Name { get; set;  }

        string[] CardsInHand { get; set; }

        int CardRank { get; set; }

    }
}