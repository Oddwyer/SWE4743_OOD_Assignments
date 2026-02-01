using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Deck;
using CrazyEights.Game;
using CrazyEights.Players;

namespace CrazyEights.Game;

public class TurnContext
{
    public ICard TopDiscard { get; private set; }
    public Suit SuitToMatch { get; private set; }
    public  int RoundNumber { get; private set; }
    

    public TurnContext(ICard topDiscard, int round, Suit suitToMatch)
    {
        TopDiscard = topDiscard;
        RoundNumber = round;
        SuitToMatch = suitToMatch;
    }
    
}

