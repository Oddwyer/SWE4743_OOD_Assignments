using System;
using CrazyEights.Deck;
using CrazyEights.Players;
using CrazyEights.Cards;
using CrazyEights.Domain;

namespace CrazyEights.Game;

public class CrazyEightsGame
{
    // Needed Variables
    public readonly List<IPlayer> players = new List<IPlayer>();
    private readonly CardDeck cardDeck;
    private readonly DiscardPile discardPile = new DiscardPile();
    public ICard TopDiscard { get; private set; }
    public string Winner { get; private set; } = "";
    public int RoundNumber { get; private set; } = 0;
    public IPlayer CurrentPlayer { get; private set; }
    private int currentIndex = 0;
    public Suit DeclardSuit { get; private set; }
    public bool MustMatchSuit {get; private set;} = false;


    // Constructor
    public CrazyEightsGame(CardDeck cardDeck, IPlayer human, IPlayer cpu)
    {
        this.cardDeck = cardDeck;
        cardDeck.ShuffleDeck();
        players.Add(human);
        players.Add(cpu);
        CurrentPlayer = human;
        discardPile.DiscardCard(cardDeck.DrawCard());
        TopDiscard = discardPile.TopDiscard();
        DeclardSuit = TopDiscard.Suit;
    }
    
    // Get Players List
    public IReadOnlyList<IPlayer> GetPlayers()
    {
        return players.AsReadOnly();
    }

    // Play Game
    public void PlayGame()
    {
        while (Winner == "")
        {
            RoundNumber++;
            CurrentPlayer = players[currentIndex];
            TurnContext context = new TurnContext(discardPile.TopDiscard(), RoundNumber, DeclardSuit, MustMatchSuit);
            RoundDetails();
            TurnAction action = CurrentPlayer.TakeTurn(context);

            if (action.DrawCard)
            {
                Console.WriteLine($"{CurrentPlayer.Name} has no playable cards. Drawing one card...\n");
                CurrentPlayer.ReceiveCard(cardDeck.DrawCard());
            }
            else 
            {
                discardPile.DiscardCard(action.DiscardedCard);
                MustMatchSuit = false;
                if (action.IsWildCard)
                {
                    MustMatchSuit = true;
                    DeclardSuit = action.WildCardSuit;
                    Console.WriteLine($"{CurrentPlayer.Name} changed suit to {DeclardSuit} {CardIcons.GetSuitIcon(DeclardSuit)}\n");
                }
            }
            currentIndex = (currentIndex + 1) % players.Count;
            Winner = GetWinner();
        }
        
        Console.WriteLine($"{Winner} won!");
    }


    // Get Winner (Is Game Over?)
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

    // Round Details for Console
    public void RoundDetails()
    {
        ICard currentCard = discardPile.TopDiscard();
        if (RoundNumber == 1)
        {
            Console.WriteLine();
            Console.WriteLine($"""
                               ==================================================
                               Crazy Eights (Simplified)
                               ==================================================
                               Starting discard: {currentCard.Rank} of {currentCard.Suit} {CardIcons.GetSuitIcon(currentCard.Suit)}
                               """);
            Console.WriteLine();
        }

        if (!MustMatchSuit)
        {
            Console.WriteLine($"""
                               ------Turn {RoundNumber}------ 
                               Top Discard: {currentCard.Rank} of {currentCard.Suit}
                               Deck Remaining: {cardDeck.DeckRemaining()}
                               {players[0].Name}: {players[0].HandCount()} cards | {players[1].Name}: {players[1].HandCount()} cards

                               ** {CurrentPlayer.Name}'s Turn
                               """);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"""
                               ------Turn {RoundNumber}------ 
                               Top Discard: {currentCard.Rank} of {currentCard.Suit} (Suit to match: {DeclardSuit})
                               Deck Remaining: {cardDeck.DeckRemaining()}
                               {players[0].Name}: {players[0].HandCount()} cards | {players[1].Name}: {players[1].HandCount()} cards

                               ** {CurrentPlayer.Name}'s Turn
                               """);
            Console.WriteLine();
        }
    }
}