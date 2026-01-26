/*Game Engine Encapsulation Requirements:
    - No public access to a player’s hand list.
    - No public mutation of the deck or discard pile.
    - State transitions (drawing, playing, discarding) must occur through methods - not list or property mutations.
    - No public fields.
*/

using CrazyEights.Players;

namespace CrazyEights.Game;

using System;
using CrazyEights.Deck;
using CrazyEights.Players;
using CrazyEights.Cards;

public class CrazyEightsGame
{
    Queue<IPlayer> players = new Queue<IPlayer>();
    private CardDeck cardDeck;
    private String winner = "";
    private bool gameOver = false;
    private DiscardPile discardPile;

    public CrazyEightsGame(CardDeck cardDeck, IPlayer human, IPlayer cpu)
    {
        this.cardDeck = cardDeck;
        players.Enqueue(human);
        players.Enqueue(cpu);
    }

    private void PlayerAction(TurnAction action)
    {
        
    }

    private bool GameOver()
    {
        return gameOver;
    }

    private void AdvanceGame()
    {
        
    }

    public void PlayGame()
    {
        throw new NotImplementedException();
    }
}