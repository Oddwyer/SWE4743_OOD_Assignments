/*Game Engine Encapsulation Requirements:
    - No public access to a player’s hand list.
    - No public mutation of the deck or discard pile.
    - State transitions (drawing, playing, discarding) must occur through methods - not list or property mutations.
    - No public fields.
*/


namespace CrazyEights.Game;

using System;
using CrazyEights.Deck;
using CrazyEights.Players;
using CrazyEights.Cards;

public class CrazyEightsGame
{
    public Queue<IPlayer> players = new Queue<IPlayer>();
    private readonly CardDeck cardDeck;
    private string winner = "";
    private readonly DiscardPile discardPile = new DiscardPile();
    private int roundNumber = 1;
    private IPlayer currentPlayer;
    private int dealCount = 0;

    public CrazyEightsGame(CardDeck cardDeck, IPlayer human, IPlayer cpu, int dealCount)
    {
        this.cardDeck = cardDeck;
        players.Enqueue(human);
        players.Enqueue(cpu);
        currentPlayer = human;
        this.dealCount = dealCount;
    }

    public void PlayerAction(TurnAction action)
    {
    }

    public string GetWinner()
    {
        if (currentPlayer.HandCount() == 0)
        {
            return currentPlayer.Name;
        }
        else if (cardDeck.IsDeckEmpty())
        {
            IPlayer player1 = players.Dequeue();
            IPlayer player2 = players.Dequeue();
            if (player1.HandCount() > player2.HandCount())
            {
                return player2.Name;
            }
            else if (player1.HandCount() == player2.HandCount())
            {
                return "It's a tie game!";
            }
            else
            {
                return player1.Name;
            }
        }
        else
        {
        }

        return "";
    }

    private void AdvanceGame()
    {
        if (winner == "")
        {
            roundNumber++;
            currentPlayer = players.Dequeue();
            TurnContext context = new TurnContext(cardDeck, discardPile, roundNumber);
            currentPlayer.TakeTurn(context);
            players.Enqueue(currentPlayer);
        }
        else
        {
            winner = GetWinner();
            Console.WriteLine($"{winner} won!");
        }
    }

    public void PlayGame()
    {
        currentPlayer = players.Dequeue();
        players.Enqueue(currentPlayer);
    }
}