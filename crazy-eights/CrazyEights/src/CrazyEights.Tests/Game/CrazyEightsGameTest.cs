using CrazyEights.Deck;
using CrazyEights.Game;
using CrazyEights.Players;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrazyEights.Tests.Game;

[TestClass]
[TestSubject(typeof(CrazyEightsGame))]
public class CrazyEightsGameTest
{

    [TestMethod]
    public void TestCreateGameEngine()
    {
        IPlayer human = new HumanPlayer("You");
        IPlayer cpu = new CpuPlayer("CPU");

        CardDeck deck = new CardDeck();
        CrazyEightsGame game = new CrazyEightsGame(deck, human, cpu);
        
        Assert.AreEqual(52, deck.DeckRemaining());

    }
}