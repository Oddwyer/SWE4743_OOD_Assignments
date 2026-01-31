/* HumanPlayer extends PlayerBase class w/ full implementation:
   - PlayerHand Method: Encapsulates player's hand and displays hand to console.
   - PlayableCards Method: Displays cards player can play in given turn.
   
   HumanPlayer Class Introduces: 
   - Create Player Constructor (name)
*/

using CrazyEights.Domain;

namespace CrazyEights.Players;

using CrazyEights.Game;
using CrazyEights.Cards;

public class HumanPlayer : PlayerBase
{
    public override string Name { get; }
    private readonly CardHand hand;

    public HumanPlayer(string name)
    {   
        Name = name;
        hand = new CardHand();
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
        
    }
    
    public override ICard RemoveCard(int index)
    {
        return new StandardCard(Suit.Clubs, Rank.Ace);
    }

    public void ViewHand()
    {
        // print hand to screen
    }
}
