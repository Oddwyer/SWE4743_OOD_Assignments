/* TurnAction (Design):
   - Contains context for player's requested actions upon turn.
*/

namespace CrazyEights.Game;

using CrazyEights.Domain;


public class TurnAction
{
    private int actionType = -1;
    private int selectedCardIndex = -1;
    private Suit selectedSuit;
}