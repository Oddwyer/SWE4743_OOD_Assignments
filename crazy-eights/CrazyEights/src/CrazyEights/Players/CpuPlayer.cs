/* CpuPlayer extends PlayerBase class w/ full implementation:
   - PlayerHand Method: Encapsulates player's hand - does NOT display hand to console.
   - PlayableCards Method: Documents cards player can play in given turn - does NOT display to console.
   - SelectCard Method: Auto selects card and passes to PlayCard method.
   - DrawCard Method: Draws card when none in hand to play; displays to screen.

   HumanPlayer Class Introduces: 
   - Create CpuPlayer Constructor: Default Name "CPU"
*/


using CrazyEights.Domain;

namespace CrazyEights.Players;

using CrazyEights.Cards;
using CrazyEights.Game;

public class CpuPlayer : PlayerBase
{
   public override string Name { get; }
   private CardHand hand;

   public CpuPlayer(string name)
   {   
      Name = name;
      hand =  new CardHand();
   }
   
   public override TurnAction TakeTurn(TurnContext context)
   {
      string action = "draw";
      int index = 1;
      Suit suit = Suit.Clubs;
      return new TurnAction(action, index, suit);
   }

   public override int HandCount()
   {
      return hand.Count();
   }

   public override IReadOnlyList<ICard> PlayableCards(TurnContext context)
   {
     return hand.PlayableCards(context);
   }

   public override void ReceiveCard(ICard card)
   {
      hand.AddCard(card);
   }
    
   public override ICard RemoveCard(int index)
   {
      return hand.RemoveCard(index);
   }
   

}

      

