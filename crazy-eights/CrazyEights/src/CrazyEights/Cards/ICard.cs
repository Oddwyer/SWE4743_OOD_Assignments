using CrazyEights.Domain;

namespace CrazyEights.Cards;

public interface ICard
{
    // Think: What must ICard have that others can view/request from every implementation of ICard?
    
    // Needed Variables
    Suit Suit { get; }
    Rank Rank { get; }

    // Is Card Wild
    public bool IsWildCard();
    
    // View Card
    public void ViewCard();
}