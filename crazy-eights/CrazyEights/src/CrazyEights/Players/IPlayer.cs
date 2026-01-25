/* IPlayer Design:
   - Minimal.
   - Define what an object can do, not how.
   - Do not expose internal state: no public fields, mutable collections.
   - No UI logic (no printing, no input handling).
   - Represent roles, define behavior - no implementation.
   - Enable polymorphism, dynamic dispatch.
      - Players must be stored as List<IPlayer>
      - The engine must call: currentPlayer.TakeTurn(context); 
         without knowing whether the player is human or computer.
   
   - Do not use if (player is HumanPlayer) or equivalent logic.
   - If the method is not required by EVERY implementation, it doesn't belong here.
   - Prefer passing a context object over many method parameters. 
*/

using CrazyEights.Game;

namespace CrazyEights.Players;

public interface IPlayer
{
    // Think: What can others ask from every implementation of iPlayer? What must iPlayer have?
    
    // Ask for player's name; must have a name.
    string Name { get; }
    
    // Ask player to take turn; must be able to take a turn.
    public TurnAction TakeTurn(TurnContext context);

    // Ask player for hand count; must have a hand count.
    public int HandCount();
}