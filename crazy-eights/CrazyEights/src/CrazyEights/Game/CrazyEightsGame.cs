using System;
using CrazyEights.Deck;
using CrazyEights.Players;
using CrazyEights.Cards;
using CrazyEights.Domain;

namespace CrazyEights.Game;

public class CrazyEightsGame
{
    public readonly List<IPlayer> players = new List<IPlayer>();
    private readonly CardDeck cardDeck;
    private readonly DiscardPile discardPile = new DiscardPile();
    public ICard TopDiscard { get; private set; }
    public string Winner { get; private set; }
    public int RoundNumber { get; private set; } = 1;
    public IPlayer CurrentPlayer { get; private set; }
    public int DealCount { get; private set; } = 0;
    private int currentIndex = 0;
    public Suit CurrentSuit { get; private set; }

    public CrazyEightsGame(CardDeck cardDeck, IPlayer human, IPlayer cpu, int dealCount)
    {
        this.cardDeck = cardDeck;
        players.Add(human);
        players.Add(cpu);
        CurrentPlayer = human;
        DealCount = dealCount;
        TopDiscard = discardPile.TopDiscard();
        CurrentSuit = TopDiscard.Suit;
    }

    public void PlayerAction(TurnAction action)
    {
        if (action.DrawCard)
        {
            CurrentPlayer.ReceiveCard(cardDeck.DrawCard());
        }
        else
        {
            discardPile.DiscardCard(action.DiscardedCard);

            if (action.IsWildCard)
            {
                CurrentSuit = action.WildCardSuit;
            }
        }
    }

    public IReadOnlyList<IPlayer> GetPlayers()
    {
        return players.AsReadOnly();
    }

    public void PlayGame()
    {
        while (Winner == "")
        {
            RoundNumber++;
            CurrentPlayer = players[currentIndex];
            TurnContext context = new TurnContext(TopDiscard, RoundNumber, TopDiscard.Suit);
            RoundDetails();
            CurrentPlayer.TakeTurn(context);
            currentIndex = (currentIndex + 1) % players.Count;
        }

        Winner = GetWinner();
        Console.WriteLine($"{Winner} won!");
    }


    public string GetWinner()
    {
        if (CurrentPlayer.HandCount() == 0)
        {
            return CurrentPlayer.Name;
        }
        else if (cardDeck.IsDeckEmpty())
        {
            if (players[0].HandCount() > players[1].HandCount())
            {
                return players[1].Name;
            }
            else if (players[0].HandCount() == players[1].HandCount())
            {
                return "It's a tie game!";
            }
            else
            {
                return players[0].Name;
            }
        }

        return "";
    }

    public void RoundDetails()
    {
        ICard currentCard = discardPile.TopDiscard();
        if (CurrentSuit == TopDiscard.Suit)
        {
            Console.WriteLine($"""
                               ------Turn {RoundNumber}------ 
                               Top Discard: {currentCard.Rank} of {currentCard.Suit}
                               Deck Remaining: {cardDeck.DeckRemaining()}
                               {players[0]}: {players[0].HandCount()} cards | {players[1]}: {players[1].HandCount()}

                               **{CurrentPlayer}'s Turn
                               """);
        }
        else
        {
            Console.WriteLine($"""
                               ------Turn {RoundNumber}------ 
                               Top Discard: {currentCard.Rank} of {currentCard.Suit} (Suit to match: {CurrentSuit})
                               Deck Remaining: {cardDeck.DeckRemaining()}
                               {players[0]}: {players[0].HandCount()} cards | {players[1]}: {players[1].HandCount()}

                               **{CurrentPlayer}'s Turn
                               """);
        }
    }
}