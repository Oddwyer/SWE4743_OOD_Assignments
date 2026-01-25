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

public class StandardCard
{
    private Suit suit { get; }
    private Rank rank { get; }
    private ICard cardType { get; }
    private bool isWild = false;

    public ICard CreateCard();
    public ICard ViewCard();

    public bool IsWildCard();
}