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
    private string name;
    private CardHand hand;

    public HumanPlayer(string name)
    {   
        this.name = name;
    }

    public override string Name => name;

    public override TurnAction TakeTurn(TurnContext context)
    {
        return new TurnAction();
    }

    public override int HandCount()
    {
        return hand.HandCount();
    }
    
    public override List<ICard> PlayableCards()
    {
        return hand.PlayableCards();
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
