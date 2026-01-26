/* Deck Class Design:
    Fields: 
    - Stack of 52 Cards
    - Deck Count
 
    Methods:
    - Create Deck Method: Instantiates new Card object 52 times, ensuring no duplicity and all card types present.
    - Shuffle Deck Method: Accepts Discard Pile and shuffles all cards.
    - Deal Cards Method: Deals initial 7 cards to each player.
    - Deck Count Method: Displays remaining number of cards; if 0 declare player with fewer cards the winner or draw if equal count.
    - Deck Empty Method: Returns true if deck is empty. 
    - Draw Method: Invoked via DrawCard Method in respective player class, draws card from deck.
*/

using CrazyEights.Cards;
using CrazyEights.Domain;

namespace CrazyEights.Deck;

public class Deck
{
    public readonly List<ICard> Cards = new List<ICard>();
    public bool IsShuffled { get; private set; } 

    public Deck()
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
    
}