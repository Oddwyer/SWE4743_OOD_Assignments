using CrazyEights.Cards;

namespace CrazyEights.Deck;

public class DiscardPile
{
    // Needed Variables
    private readonly Stack<ICard> cards = new Stack<ICard>();

    // Add Card to Discard Pile
    public void DiscardCard(ICard card)
    {
        cards.Push(card);
    }

    // View Top Card in Pile
    public ICard TopDiscard()
    {
        if (cards.Count != 0)
        {
            return cards.Peek();
        }
        return null;
    }

    // Discard Pile Count
    public int DiscardCount()
    {
        return cards.Count;
    }
}