/* TurnContext (Design):
   - Contains context for current game details to provide insight for turn actions.
*/
namespace CrazyEights.Game;

using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Deck;
using CrazyEights.Game;
using CrazyEights.Players;

public class TurnContext
{
    public DiscardPile DiscardPile { get; }
    public Suit SuitToMatch { get; }
    public int RoundNumber { get; }
    public ICard CurrentCard { get; }
    public CardDeck Deck { get; }
    


    public TurnContext(CardDeck deck, DiscardPile discardPile, int round)
    {
        DiscardPile = discardPile;
        SuitToMatch = discardPile.TopDiscard().Suit;
        RoundNumber = round;
        CurrentCard = discardPile.TopDiscard();
        Deck = deck;
    }
}

