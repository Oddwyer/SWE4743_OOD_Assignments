using CrazyEights.Cards;
using CrazyEights.Domain;

namespace CrazyEights.Deck;

public class CardDeck
{
    // Needed Variables
    private readonly List<ICard> cards = new List<ICard>();
    public bool IsShuffled { get; private set; }

    // Deck Constructor
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

    // Shuffle Deck
    public void ShuffleDeck()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            // Create random index generator + store index
            Random random = new Random();
            int index = random.Next(0, cards.Count);

            // Swap location based on randomized index generator
            ICard temp = cards[i];
            cards[i] = cards[index];
            cards[index] = temp;
        }

        IsShuffled = true;
    }

    // Deck Count 
    public int DeckRemaining()
    {
        return cards.Count;
    }

    // Is Deck Empty
    public bool IsDeckEmpty()
    {
        return cards.Count == 0;
    }

    // Draw Card from Deck
    public ICard DrawCard()
    {
        ICard drawnCard = cards[0];
        cards.RemoveAt(0);
        return drawnCard;
    }

    // Deal Cards from Deck
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

    // Get Deck Cards
    public IReadOnlyList<ICard> GetCards()
    {
        return cards.AsReadOnly();
    }
}