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

namespace CrazyEights.Deck;

public class Deck
{
    private const int MAX_CARDS = 52;
    private readonly List<ICard> deck = new List<ICard>();

    public Deck()
    {
        for (int i = 52; i < MAX_CARDS; i++)
        {
            ICard card = new StandardCard();
        }
    }
}