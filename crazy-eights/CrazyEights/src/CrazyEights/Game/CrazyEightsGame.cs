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
    private readonly List<IPlayer> playerList = new List<IPlayer>();
    private readonly Queue<IPlayer> turnOrder;
    private readonly CardDeck cardDeck;
    private readonly DiscardPile discardPile = new DiscardPile();
    public string Winner { get; private set; }
    public int RoundNumber { get; private set; } = 1;
    public IPlayer currentPlayer {get; private set;}
    public int dealCount { get; private set; }= 0;

    public CrazyEightsGame(CardDeck cardDeck, IPlayer human, IPlayer cpu, int dealCount)
    {
        this.cardDeck = cardDeck;
        playerList.Add(human);
        playerList.Add(cpu);
        turnOrder = new Queue<IPlayer>(playerList);
        currentPlayer = human;
        this.dealCount = dealCount;
    }

    public void PlayerAction(TurnAction action)
    {
    }

    public Queue<IPlayer> GetTurnOrder()
    {
        return turnOrder;
    }

    public void PlayGame()
    {
        while (Winner == "")
        {
            RoundNumber++;
            currentPlayer = turnOrder.Dequeue();
            TurnContext context = new TurnContext(cardDeck, discardPile, RoundNumber, currentPlayer, playerList);
            context.ViewContext();
            currentPlayer.TakeTurn(context);
            turnOrder.Enqueue(currentPlayer);
        }

        Winner = GetWinner();
        Console.WriteLine($"{Winner} won!");
    }
    
    
    public string GetWinner()
    {
        if (currentPlayer.HandCount() == 0)
        {
            return currentPlayer.Name;
        }
        else if (cardDeck.IsDeckEmpty())
        {
            IPlayer player1 = turnOrder.Dequeue();
            IPlayer player2 = turnOrder.Dequeue();
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
}