using CrazyEights.Cards;
using CrazyEights.Deck;
using CrazyEights.Game;
using CrazyEights.Players;


namespace CrazyEights;

public static class Program
{
    public static void Main(string[] args)
    {
        IPlayer human = new HumanPlayer("You");
        IPlayer cpu = new CpuPlayer("CPU");

        CardDeck deck = new CardDeck();
        CrazyEightsGame game = new CrazyEightsGame(deck, human, cpu);

        game.PlayGame();
    }
}