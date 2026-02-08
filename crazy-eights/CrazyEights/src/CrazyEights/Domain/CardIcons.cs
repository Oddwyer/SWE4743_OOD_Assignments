namespace CrazyEights.Domain;
/// <summary>
/// Provides shapes corresponding to card suit.
/// </summary>
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