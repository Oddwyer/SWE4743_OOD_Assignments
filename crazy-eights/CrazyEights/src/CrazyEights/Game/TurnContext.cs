/* TurnContext (Design):
   - Contains context for current game details to provide insight for turn actions.
*/
namespace CrazyEights.Game;

using CrazyEights.Cards;
using CrazyEights.Domain;
using CrazyEights.Deck;
using CrazyEights.Game;
using CrazyEights.Players;

public class TurnContext
{
    private DiscardPile discardPile;
    private Suit suitToMatch;
    private readonly int roundNumber;
    private readonly ICard currentCard;
    private readonly CardDeck gameDeck;
    private readonly IPlayer currentPlayer;
    private readonly List<IPlayer> currentPlayerList;
    

    public TurnContext(CardDeck deck, DiscardPile discardPile, int round, IPlayer player, List<IPlayer> playerList)
    {
        this.discardPile = discardPile;
        suitToMatch = discardPile.TopDiscard().Suit;
        roundNumber = round;
        currentCard = discardPile.TopDiscard();
        gameDeck = deck;
        currentPlayer = player;
        currentPlayerList = playerList;
    }

    public ICard GetCurrentCard()
    {
        return currentCard;
    }

    public int GetRoundNumber()
    {
        return roundNumber;
    }
    
    public void ViewContext()
    {
        Console.WriteLine($"""
                           ------Turn {roundNumber}------ 
                           Top Discard: {currentCard.Rank} of {currentCard.Suit}
                           Deck Remaining: {gameDeck.DeckRemaining()}
                           {currentPlayerList[0]}: {currentPlayerList[0].HandCount()} cards | {currentPlayerList[1]}: {currentPlayerList[1].HandCount()}
                           
                           **{currentPlayer}'s Turn
                           """);
    }
}

