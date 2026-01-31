/* TurnContext (Design):
   - Contains context for current game details to provide insight for turn actions.
*/
namespace CrazyEights.Game;

using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Players;

public class TurnContext
{
    private ICard TopDiscard { get; }
    private Suit SuitToMatch { get; }
    private int RoundNumber { get; }


    /*public TurnContext CurrentTurnContext()
    {
    }*/
}

