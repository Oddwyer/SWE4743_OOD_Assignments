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
    private DiscardPile DiscardPile { get; }
    private Suit SuitToMatch { get; }
    public int RoundNumber { get; }
    private ICard CurrentCard { get; }


    public TurnContext(CardDeck deck, DiscardPile discardPile, int round)
    {
        DiscardPile = discardPile;
        SuitToMatch = discardPile.TopDiscard().Suit;
        RoundNumber = round;
        CurrentCard = discardPile.TopDiscard();
    }
}

