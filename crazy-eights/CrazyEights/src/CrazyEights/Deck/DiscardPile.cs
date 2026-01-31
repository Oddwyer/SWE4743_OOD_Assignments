using CrazyEights.Cards;

namespace CrazyEights.Deck;

/* DiscardPile Class Design:
    - Top Discard Method: Displays last card played.
    - Match Suit Method: Displays suit to match.
    - Discard Method: Discards card onto discard pile. 
*/

public class DiscardPile
{
    private readonly Stack<ICard> cards = new Stack<ICard>();

    public void DiscardCard(ICard card)
    {
        cards.Push(card);
    }

    public ICard DiscardPeek()
    {
       return cards.Peek();
    }

    public int DiscardCount()
    {
        return cards.Count;
    }
}