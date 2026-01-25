/* HumanPlayer extends PlayerBase class w/ full implementation:
   - PlayerHand Method: Encapsulates player's hand and displays hand to console.
   - PlayableCards Method: Displays cards player can play in given turn.
   
   HumanPlayer Class Introduces: 
   - Create Player Constructor (name)
*/

namespace CrazyEights.Players;

using CrazyEights.Game;
using CrazyEights.Cards;

public class HumanPlayer : PlayerBase
{
    private string playerName;
    private CardHand playerHand;

    public HumanPlayer(string name)
    {   
        playerName = name;
    }

    public override TurnAction TakeTurn(TurnContext context)
    {
        return new TurnAction();
    }

    public override int HandCount()
    {
        return playerHand.HandCount();
    }
    
    public override List<ICard> PlayableCards()
    {
        return playerHand.PlayableCards();
    }
    
    public override void ReceiveCard(ICard card)
    {
        
    }
    
    public override ICard RemoveCard(int index)
    {
    }

    public void ViewHand()
    {
        // print hand to screen
    }
}
