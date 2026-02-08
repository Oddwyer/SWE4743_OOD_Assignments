using CrazyEights.Cards;
using CrazyEights.Game;

namespace CrazyEights.Players;
/// <summary>
/// Methods such as RemoveCard and PlayableCards are located under CardHand.
/// </summary>

public abstract class PlayerBase : IPlayer {

      // Inherits IPlayer Naming Requirements.
      public abstract string Name { get; }
      
      // Encapsulates Player's Hand.
      public CardHand Hand { get; }

      // Inherits IPlayer Methods + Introduces Helper Logic.
      public abstract TurnAction TakeTurn(TurnContext context);
      
      public abstract int HandCount();
   
      public abstract void ReceiveCard(ICard card);
}