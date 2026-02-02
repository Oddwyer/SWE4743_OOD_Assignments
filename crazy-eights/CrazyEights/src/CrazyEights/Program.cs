using CrazyEights.Cards;
using CrazyEights.Deck;
using CrazyEights.Game;
using CrazyEights.Players;

namespace CrazyEights;

public static class Program
{
    public static void Main(string[] args)
    {
        CardDeck deck = new CardDeck();
        deck.ShuffleDeck();
        Console.Write("Enter your name (or press Enter for 'Player'): ");
        string name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            name = "Player";
        }
        IPlayer human1 = new HumanPlayer(name, new CardHand(deck.DealCards(5)));
        IPlayer human2 = new HumanPlayer("P2", new CardHand(deck.DealCards(5)));
        //IPlayer cpu = new CpuPlayer("CPU", new CardHand(deck.DealCards(5)));

     
        CrazyEightsGame game = new CrazyEightsGame(deck, human1, human2);

        game.PlayGame();
    }
}