namespace PokerGameCheckerMicroservice.Models
{
    public class PokerDataGenerator
    {
        public int TotalPlayers {get; set;}
        public bool isFlush { get; set; }
        public bool isRandom {get; set;}
        public int nKinds { get; set; }
        public bool isStraight { get; set; }
        public bool isUniqueCards {get; set;}
    }
}