using CrazyEights.Game;

namespace CrazyEights.Cards;

public class CardHand
{
    public readonly List<ICard> Hand;
    private readonly List<ICard> playableCards;
    private int handCount;

    public CardHand()
    {
        Hand = new List<ICard>();
        playableCards = new List<ICard>();
        handCount = 0;
    }

    public CardHand(List<ICard> cards)
    {
        Hand = cards;
        playableCards = new List<ICard>();
        handCount = cards.Count;
    }

    public IReadOnlyList<ICard> ViewHand()
    {
        return Hand;
    }

    public IReadOnlyList<ICard> PlayableCards(TurnContext context)
    {
        foreach (var card in Hand)
        {
            if (card.IsWildCard())
            {
                playableCards.Add(card);
            }
            else if (card.Suit == context.CurrentCard.Suit)
            {
                playableCards.Add(card);
            }
            else if (card.Rank == context.CurrentCard.Rank)
            {
                playableCards.Add(card);
            }
        }

        return playableCards;
    }

    public int Count()
    {
        return Hand.Count;
    }

    public void AddCard(ICard card)
    {
        Hand.Add(card);
    }

    public ICard RemoveCard(int index)
    {
        ICard card = Hand[index];
        Hand.RemoveAt(index);
        return card;
    }
}