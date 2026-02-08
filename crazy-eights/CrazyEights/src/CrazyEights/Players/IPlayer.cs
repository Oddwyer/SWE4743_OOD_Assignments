using CrazyEights.Cards;
using CrazyEights.Game;

namespace CrazyEights.Players;

/// <summary>
/// Think: What must IPlayer have that others may view/request from every implementation of IPlayer?
/// Think: What will game engine need to call for IPlayer?
/// </summary>
public interface IPlayer
{
    // Needed Variables
    public string Name { get; }
    
    // Must Take Turn
    public TurnAction TakeTurn(TurnContext context);

    // Must Receive Card
    public void ReceiveCard(ICard card);
    
    // Must Have Hand Count
    public int HandCount();
}