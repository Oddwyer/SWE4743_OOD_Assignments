using CrazyEights.Deck;
using CrazyEights.Players;
using CrazyEights.Cards;
using CrazyEights.Domain;

namespace CrazyEights.Game;

public class CrazyEightsGame
{
    // Needed Variables
    public readonly List<IPlayer> Players = new List<IPlayer>();
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
        Players.Add(human);
        Players.Add(cpu);
        CurrentPlayer = human;
        discardPile.DiscardCard(cardDeck.DrawCard());
        TopDiscard = discardPile.TopDiscard();
        DeclardSuit = TopDiscard.Suit;
    }
    
    // Get Players List
    public IReadOnlyList<IPlayer> GetPlayers()
    {
        return Players.AsReadOnly();
    }

    // Play Game
    public void PlayGame()
    {
        while (Winner == "")
        {
            RoundNumber++;
            CurrentPlayer = Players[currentIndex];
            // Create & Pass turn context details to players 
            TurnContext context = new TurnContext(discardPile.TopDiscard(), RoundNumber, DeclardSuit, MustMatchSuit);
            
            // Print Round/Turn Details to Console
            RoundDetails();
            
            // Invoke Player's Turn & Receive Directives
            TurnAction action = CurrentPlayer.TakeTurn(context);

            // Perform Action Per Directives
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
            // Update Player
            currentIndex = (currentIndex + 1) % Players.Count;
            // Check if Game Over
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
            if (Players[0].HandCount() > Players[1].HandCount())
            {
                return Players[1].Name;
            }
            else if (Players[0].HandCount() == Players[1].HandCount())
            {
                return "It's a tie game!";
            }
            else
            {
                return Players[0].Name;
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
                               Top Discard: {currentCard.Rank} of {currentCard.Suit} {CardIcons.GetSuitIcon(currentCard.Suit)}
                               Deck Remaining: {cardDeck.DeckRemaining()}
                               {Players[0].Name}: {Players[0].HandCount()} cards | {Players[1].Name}: {Players[1].HandCount()} cards

                               ** {CurrentPlayer.Name}'s Turn
                               """);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"""
                               ------Turn {RoundNumber}------ 
                               Top Discard: {currentCard.Rank} of {currentCard.Suit} {CardIcons.GetSuitIcon(currentCard.Suit)}(Suit to match: {DeclardSuit})
                               Deck Remaining: {cardDeck.DeckRemaining()}
                               {Players[0].Name}: {Players[0].HandCount()} cards | {Players[1].Name}: {Players[1].HandCount()} cards

                               ** {CurrentPlayer.Name}'s Turn
                               """);
            Console.WriteLine();
        }
    }
}