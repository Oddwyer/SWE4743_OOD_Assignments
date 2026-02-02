using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Game;

namespace CrazyEights.Players;
/// <summary>
/// Methods such as "remove card" are located under CardHand.
/// </summary>

public abstract class PlayerBase : IPlayer {

      // Inherits IPlayer naming requirements.
      public abstract string Name { get; }
      
      // Encapsulates player's hand.
      public CardHand Hand { get; }

      // Inherits IPlayer methods + introduces helper logic.
      public abstract TurnAction TakeTurn(TurnContext context);
      
      public abstract int HandCount();

      public abstract IReadOnlyList<ICard> PlayableCards(TurnContext context);
      
      public abstract void ReceiveCard(ICard card);
}