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
    public Suit DeclaredSuit { get; private set; }
    public  int RoundNumber { get; private set; }
    public bool MustMatchSuit { get; private set; }
    

    // Constructor
    public TurnContext(ICard topDiscard, int round, Suit declaredSuit, bool mustMatchSuit = false)
    {
        if (!mustMatchSuit)
        {
            DeclaredSuit = topDiscard.Suit;
        }
        else
        {
            DeclaredSuit = declaredSuit;
        }
        TopDiscard = topDiscard;
        RoundNumber = round;
        MustMatchSuit = mustMatchSuit;
    }
    
}

