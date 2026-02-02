using CrazyEights.Cards;
using CrazyEights.Domain;

namespace CrazyEights.Game;
/// <summary>
/// Purpose: Relay Turn Details to Players (Namely CPU Who Cannot Read Screen)
/// </summary>
public class TurnContext
{
    // Needed Variables to Inform Player
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

