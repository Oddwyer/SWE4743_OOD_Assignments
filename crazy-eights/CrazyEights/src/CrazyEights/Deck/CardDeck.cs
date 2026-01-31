using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Players;

namespace CrazyEights.Deck;

public class CardDeck
{
    public readonly List<ICard> Cards = new List<ICard>();
    public bool IsShuffled { get; private set; } 

    public CardDeck()
    {
        for (Suit suit = 0; suit <= Suit.Spades; suit++)
        {
            for (Rank rank = Rank.Two; rank <= Rank.Ace; rank++)
            {
                ICard card = new StandardCard(suit, rank);
                Cards.Add(card);
            }
        }
    }

    // ShuffleDeck Method:
    public void ShuffleDeck()
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            // create random index generator + store index
            Random random = new Random();
            int index = random.Next(0, Cards.Count);
            
            // swap location based on randomized index generator
            ICard temp = Cards[i]; 
            Cards[i] = Cards[index];
            Cards[index] = temp;
        }

        IsShuffled =  true;
    }

    public int DeckRemaining()
    {
        return Cards.Count;
    }

    public bool IsDeckEmpty()
    {
        return Cards.Count == 0;
    }

    public ICard DrawCard()
    {
        ICard drawnCard = Cards[0];
        Cards.RemoveAt(0);
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
    
}