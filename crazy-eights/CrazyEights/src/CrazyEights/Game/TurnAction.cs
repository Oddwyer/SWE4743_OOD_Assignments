using CrazyEights.Cards;
using CrazyEights.Domain;

namespace CrazyEights.Game;

public class TurnAction
{
    public bool DrawCard { get; private set; } = false;
    public ICard DiscardedCard { get; private set; }
    
    public bool IsWildCard { get; private set; } = false;
    public Suit WildCardSuit { get; private set; }

    public TurnAction(bool draw, ICard card, Suit suit, bool isWild)
    {
        DrawCard = draw;
        DiscardedCard = card;
        WildCardSuit = suit;
        IsWildCard = isWild;
    }
}