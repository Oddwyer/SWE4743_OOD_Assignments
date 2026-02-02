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
        IPlayer human = new HumanPlayer("You", new CardHand(deck.DealCards(5)));
        IPlayer cpu = new CpuPlayer("CPU", new CardHand(deck.DealCards(5)));

     
        CrazyEightsGame game = new CrazyEightsGame(deck, human, cpu);

        game.PlayGame();
    }
}