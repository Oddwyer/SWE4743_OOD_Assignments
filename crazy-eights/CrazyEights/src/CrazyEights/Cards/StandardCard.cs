/* StandardCard will implement iCard:
   
   StandardCard Class Introduces:
    Data Fields: 
      - Suit
      - Rank
      - List StandardCard (not duplicated).
      - Rank of 8 is a wildcard.
    Methods:
    - Card Constructor: Creates card invoking Suit and Rank class methods.
    - IsWildCard Method: Confirms card is wildcard (rank of 8).      
*/
namespace CrazyEights.Cards;

using CrazyEights.Domain;

public class StandardCard : ICard
{
    private Suit suit;
    private Rank rank;
    private bool isWild = false;

    public StandardCard()
    {
        suit = new Suit();
        rank = new Rank();
    }

    public bool IsWildCard()
    {
        return isWild;
    }
    
    public void ViewCard()
    {
        Console.WriteLine($"{rank} of {suit}");
    }
}