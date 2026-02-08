using CrazyEights.Cards;
using CrazyEights.Domain;

namespace CrazyEights.Game;
/// <summary>
/// Purpose: Relay turn details to players (namely CPU who cannot read screen).
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

