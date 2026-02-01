using CrazyEights.Domain;

namespace CrazyEights.Cards;

public interface ICard
{
    // Think: What must ICard have that others can view/request from every implementation of ICard?
    Suit Suit { get; }
    Rank Rank { get; }

    // May request if wildcard.
    public bool IsWildCard();
    
    // Must view card.
    public void ViewCard();
}