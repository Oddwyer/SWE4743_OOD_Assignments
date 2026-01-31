/* TurnAction (Design):
   - Contains context for player's requested actions upon turn.
*/

namespace CrazyEights.Game;

using CrazyEights.Domain;


public class TurnAction
{
    public string ActionType {get; }
    public int SelectedCardIndex { get; }
    public Suit SelectedSuit { get; }

    public TurnAction(string action, int index, Suit suit)
    {
        ActionType = action;
        SelectedCardIndex = index;
        SelectedSuit = suit;
    }
}
