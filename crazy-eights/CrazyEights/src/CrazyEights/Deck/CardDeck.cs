using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Players;

namespace CrazyEights.Deck;

public class CardDeck
{
    private readonly List<ICard> cards = new List<ICard>();
    public bool IsShuffled { get; private set; }

    public CardDeck()
    {
        for (Suit suit = 0; suit <= Suit.Spades; suit++)
        {
            for (Rank rank = Rank.Two; rank <= Rank.Ace; rank++)
            {
                ICard card = new StandardCard(suit, rank);
                cards.Add(card);
            }
        }
    }

    // ShuffleDeck Method:
    public void ShuffleDeck()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            // create random index generator + store index
            Random random = new Random();
            int index = random.Next(0, cards.Count);

            // swap location based on randomized index generator
            ICard temp = cards[i];
            cards[i] = cards[index];
            cards[index] = temp;
        }

        IsShuffled = true;
    }

    public int DeckRemaining()
    {
        return cards.Count;
    }

    public bool IsDeckEmpty()
    {
        return cards.Count == 0;
    }

    public ICard DrawCard()
    {
        ICard drawnCard = cards[0];
        cards.RemoveAt(0);
        return drawnCard;
    }

    public List<ICard> DealCards(int dealCount)
    {
        List<ICard> dealtCards = new List<ICard>();
        int count = 0;
        while (count < dealCount)
        {
            dealtCards.Add(DrawCard());
            count++;
        }

        return dealtCards;
    }

    public IReadOnlyList<ICard> GetCards()
    {
        return cards.AsReadOnly();
    }
}