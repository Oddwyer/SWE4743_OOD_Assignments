/* TurnContext (Design):
   - Contains context for current game details to provide insight for turn actions.
*/
namespace CrazyEights.Game;

using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Players;

public class TurnContext
{
    private ICard topDiscard;
    private Suit suitToMatch;
    private int roundNumber = 0;
    private IPlayer currentPlayer;
}