using CrazyEights.Game;

namespace CrazyEights.Cards;

public class CardHand
{
    private readonly List<ICard> hand;
    private readonly List<ICard> playableCards;


    public CardHand()
    {
        hand = new List<ICard>();
        playableCards = new List<ICard>();
    }

    public CardHand(List<ICard> cards)
    {
        hand = cards;
        playableCards = new List<ICard>();
    }

    public IReadOnlyList<ICard> ViewHand()
    {
        return hand.AsReadOnly();
    }

    public IReadOnlyList<ICard> PlayableCards(TurnContext context)
    {
        foreach (var card in hand)
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
        return hand.Count;
    }

    public void AddCard(ICard card)
    {
        hand.Add(card);
    }

    public ICard RemoveCard(int index)
    {
        ICard card = hand[index];
        hand.RemoveAt(index);
        return card;
    }
}