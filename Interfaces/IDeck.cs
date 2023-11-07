namespace Interfaces
{
    public interface IDeck
    {
        int TotalCards { get; set; }
        List<IPlayer> Player { get; set; }

    }
}