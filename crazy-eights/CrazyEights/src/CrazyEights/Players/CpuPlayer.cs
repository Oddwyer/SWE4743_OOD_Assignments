using CrazyEights.Domain;
using CrazyEights.Cards;
using CrazyEights.Game;

namespace CrazyEights.Players;

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
      Console.WriteLine();
      bool draw = false;
      bool isWildCard = false;
      ICard discardedCard = new StandardCard(Suit.Diamonds, Rank.Ace);
      Suit wildCardSuit =  Suit.Clubs;   
            
      return new TurnAction(draw, discardedCard, wildCardSuit, isWildCard);
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

      

