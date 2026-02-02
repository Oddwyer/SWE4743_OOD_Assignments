using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Deck;
using CrazyEights.Game;
using CrazyEights.Players;

namespace CrazyEights.Game;
/// <summary>
/// Purpose: Relay Turn Details to CPU
/// </summary>
public class TurnContext
{
    // Needed Variables
    public ICard TopDiscard { get; private set; }
    public Suit SuitToMatch { get; private set; }
    public  int RoundNumber { get; private set; }
    

    // Constructor
    public TurnContext(ICard topDiscard, int round, Suit suitToMatch)
    {
        TopDiscard = topDiscard;
        RoundNumber = round;
        SuitToMatch = suitToMatch;
    }
    
}

