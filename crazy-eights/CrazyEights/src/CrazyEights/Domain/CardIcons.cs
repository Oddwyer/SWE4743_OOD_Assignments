

namespace CrazyEights.Domain;

public class CardIcons
{
    public static string GetSuitIcon(Suit suit)
    {
        switch (suit)
        {
            case Suit.Clubs:
                return "♣";
            case Suit.Diamonds:
                return "♦";
            case Suit.Hearts:
                return "♥";
            case Suit.Spades:
                return "♠";
            default:
                return "";
        }
    }    
}