using CrazyEights.Cards;
using CrazyEights.Game;

namespace CrazyEights.Players;

public interface IPlayer
{
    // Think: What must IPlayer have that others may view/request from every implementation of IPlayer?
    
    public string Name { get; }
    
    // Must take turn.
    public TurnAction TakeTurn(TurnContext context);

    // Must receive card.
    public void ReceiveCard(ICard card);
    
    // Must have hand count.
    public int HandCount();
}