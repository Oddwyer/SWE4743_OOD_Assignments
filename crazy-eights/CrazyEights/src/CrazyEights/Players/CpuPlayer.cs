using CrazyEights.Domain;
using CrazyEights.Cards;
using CrazyEights.Game;

namespace CrazyEights.Players;

public class CpuPlayer : PlayerBase
{
   // Needed Variables
   public override string Name { get; }
   private CardHand hand;

   // Constructor
   public CpuPlayer(string name, CardHand hand)
   {   
      Name = name;
      this.hand = hand;
   }
   
   // CPU Turn Actions
   public override TurnAction TakeTurn(TurnContext context)
   {
      Console.WriteLine();
      bool draw = false;
      bool isWildCard = false;
      ICard discardedCard = new StandardCard(Suit.Diamonds, Rank.Ace);
      Suit wildCardSuit =  Suit.Clubs;   
            
      return new TurnAction(draw, discardedCard, wildCardSuit, isWildCard);
   }

   // CPU Hand Count
   public override int HandCount()
   {
      return hand.Count();
   }

   // CPU Playable Cards
   public override IReadOnlyList<ICard> PlayableCards(TurnContext context)
   {
     return hand.PlayableCards(context);
   }

   // CPU Add Card to Hand
   public override void ReceiveCard(ICard card)
   {
      hand.AddCard(card);
   }
   
}

      

