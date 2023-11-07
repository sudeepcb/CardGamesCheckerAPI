using System; 

public interface ICardGame
{
    public int TotalPlayers { get; set; }

    List<Deck> DeckPerPlayers { get; set; }
    

}