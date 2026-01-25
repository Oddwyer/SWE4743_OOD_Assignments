/* PlayerBase implements IPlayer interface:
   - Encapsulates the player’s hand
   - Provides shared helper logic (finding playable cards, removing cards, etc.)
   - Leaves decision-making to subclasses
*/

using CrazyEights.Cards;
using CrazyEights.Game;

namespace CrazyEights.Players;

public abstract class PlayerBase : IPlayer {

      // Inherits IPlayer naming requirements.
      public abstract string Name { get; }
      // Encapsulates player's hand.
      public abstract CardHand PlayerHand { get; }

      // Inherits IPlayer methods + introduces helper logic.
      public abstract TurnAction TakeTurn(TurnContext context);
      
      public abstract int HandCount();

      public abstract List<ICard> PlayableCards();
      
      public abstract ICard RemoveCard(int index);
      
      public abstract void ReceiveCard(ICard card);
}