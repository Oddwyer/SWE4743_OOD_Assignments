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
    // Think: What must IPlayer have that others may view/request from every implementation of IPlayer?
    
    string Name { get; }
    
    // Must take turn.
    public TurnAction TakeTurn(TurnContext context);

    // Must have hand count.
    public int HandCount();
}