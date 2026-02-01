using CrazyEights.Domain;

namespace CrazyEights.Cards;

public class StandardCard : ICard
{
    // needed variables
    public bool IsWild { get; private set; } = false;
    
    // needed variables established as property methods
    public Suit Suit { get; }
    public Rank Rank { get; }
    
    // constructor
    public StandardCard(Suit suit, Rank rank)
    {
        this.Suit = suit;
        this.Rank = rank;
        if(rank == Rank.Eight){
            IsWild = true;
        }
    }

    // returns if card is a wildcard (cards with rank of 8 are wild)
    public bool IsWildCard()
    {
        return IsWild;
    }

    // view card - only need to print to console to view
    public void ViewCard()
    {
        Console.WriteLine($"{Rank} of {Suit}");
    }
}