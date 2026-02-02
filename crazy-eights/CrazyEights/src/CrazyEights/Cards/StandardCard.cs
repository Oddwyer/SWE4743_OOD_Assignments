using CrazyEights.Domain;

namespace CrazyEights.Cards;

public class StandardCard : ICard
{
    // Needed Variables
    public bool IsWild { get; private set; } = false;
    public Suit Suit { get; private set; }
    public Rank Rank { get; private set; }
    
    // Constructor
    public StandardCard(Suit suit, Rank rank)
    {
        this.Suit = suit;
        this.Rank = rank;
        if(rank == Rank.Eight){
            IsWild = true;
        }
    }

    // Returns if Card is Wild (Has Rank of 8)
    public bool IsWildCard()
    {
        return IsWild;
    }

    // View Card (Print Only)
    public void ViewCard()
    {
        Console.WriteLine($"{Rank} of {Suit}");
    }
}