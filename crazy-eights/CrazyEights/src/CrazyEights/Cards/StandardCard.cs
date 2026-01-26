/* StandardCard will implement ICard:
    Data Fields: 
      - Suit
      - Rank
      - Rank of 8 is a wildcard.
    Methods:
    - Card Constructor: Creates card invoking Suit and Rank class methods.
    - IsWildCard Method: Confirms card is wildcard (rank of 8).  
    - ViewCard Method: Prints card details to screen.
*/
namespace CrazyEights.Cards;

using CrazyEights.Domain;

public class StandardCard : ICard
{
    // needed variables
    private bool isWild = false;
    
    // needed variables established as property methods
    public Suit Suit { get; }
    public Rank Rank { get; }
    
    // constructor
    public StandardCard(Suit suit, Rank rank)
    {
        this.Suit = suit;
        this.Rank = rank;
        if(rank == Rank.Eight){
            isWild = true;
        }
    }

    // returns if card is a wildcard (cards with rank of 8 are wild)
    public bool IsWildCard()
    {
        return isWild;
    }

    // view card - only need to print to console to view
    public void ViewCard()
    {
        Console.WriteLine($"{Rank} of {Suit}");
    }
}