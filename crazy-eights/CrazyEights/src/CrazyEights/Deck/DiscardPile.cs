using CrazyEights.Cards;

namespace CrazyEights.Deck;

public class DiscardPile
{
    private readonly Stack<ICard> cards = new Stack<ICard>();

    public void DiscardCard(ICard card)
    {
        cards.Push(card);
    }

    public ICard TopDiscard()
    {
        if (cards.Count != 0)
        {
            return cards.Peek();
        }
        return null;
    }

    public int DiscardCount()
    {
        return cards.Count;
    }
}