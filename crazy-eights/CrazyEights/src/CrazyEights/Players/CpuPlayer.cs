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

      

