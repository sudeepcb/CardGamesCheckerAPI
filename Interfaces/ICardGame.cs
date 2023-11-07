namespace Interfaces
{
    public interface ICardGame
    {
        int TotalPlayers { get; set; }

        List<IDeck> AllDecks { get; set; }

        IPlayer DetermineWinner();

    }

}