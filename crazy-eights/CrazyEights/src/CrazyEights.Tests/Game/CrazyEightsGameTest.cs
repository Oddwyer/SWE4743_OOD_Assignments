using CrazyEights.Cards;
using CrazyEights.Deck;
using CrazyEights.Domain;
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
        CrazyEightsGame game = new CrazyEightsGame(deck, human, cpu, 5);

        Assert.AreEqual(52, deck.DeckRemaining());
        Assert.IsNotNull(game);
        Assert.IsInstanceOfType(game, typeof(CrazyEightsGame));
        Assert.AreEqual(2, game.GetTurnOrder().Count);
    }

    [TestMethod]
    public void TestGameOverCPU()
    {
        // arrange
        HumanPlayer human = new HumanPlayer("You");
        CpuPlayer cpu = new CpuPlayer("CPU");
        CardDeck deck = new CardDeck();

        // act
        human.ReceiveCard(new StandardCard(Suit.Clubs, Rank.Ace));
        human.ReceiveCard(new StandardCard(Suit.Clubs, Rank.King));
        cpu.ReceiveCard(new StandardCard(Suit.Clubs, Rank.Ace));
        while (!deck.IsDeckEmpty() && deck.DeckRemaining() > 0)
        {
            deck.DrawCard();
        }

        CrazyEightsGame game = new CrazyEightsGame(deck, human, cpu, 0);

        // assert
        Assert.AreEqual("CPU", game.GetWinner());
    }

    [TestMethod]
    public void TestGameOverHuman()
    {
        // arrange
        HumanPlayer human = new HumanPlayer("You");
        CpuPlayer cpu = new CpuPlayer("CPU");
        CardDeck deck = new CardDeck();

        // act
        human.ReceiveCard(new StandardCard(Suit.Clubs, Rank.Ace));
        cpu.ReceiveCard(new StandardCard(Suit.Clubs, Rank.King));
        cpu.ReceiveCard(new StandardCard(Suit.Clubs, Rank.Ace));
        while (!deck.IsDeckEmpty() && deck.DeckRemaining() > 0)
        {
            deck.DrawCard();
        }

        CrazyEightsGame game = new CrazyEightsGame(deck, human, cpu, 0);

        // assert
        Assert.AreEqual("You", game.GetWinner());
    }

    [TestMethod]
    public void TestGameOverTie()
    {
        // arrange
        HumanPlayer human = new HumanPlayer("You");
        CpuPlayer cpu = new CpuPlayer("CPU");
        CardDeck deck = new CardDeck();

        // act
        human.ReceiveCard(new StandardCard(Suit.Clubs, Rank.Ace));
        cpu.ReceiveCard(new StandardCard(Suit.Clubs, Rank.King));
        while (!deck.IsDeckEmpty() && deck.DeckRemaining() > 0)
        {
            deck.DrawCard();
        }

        CrazyEightsGame game = new CrazyEightsGame(deck, human, cpu, 0);

        // assert
        Assert.AreEqual("It's a tie game!", game.GetWinner());
    }

    [TestMethod]
    public void TestGameOverZeroHuman()
    {
        // arrange
        HumanPlayer human = new HumanPlayer("You");
        CpuPlayer cpu = new CpuPlayer("CPU");
        CardDeck deck = new CardDeck();

        // act
        cpu.ReceiveCard(new StandardCard(Suit.Clubs, Rank.King));
        while (!deck.IsDeckEmpty() && deck.DeckRemaining() > 0)
        {
            deck.DrawCard();
        }

        CrazyEightsGame game = new CrazyEightsGame(deck, human, cpu, 0);

        // assert
        Assert.AreEqual("You", game.GetWinner());
    }

    [TestMethod]
    public void TestGameOverNotEmptyDeck()
    {
        // arrange
        HumanPlayer human = new HumanPlayer("You");
        CpuPlayer cpu = new CpuPlayer("CPU");
        CardDeck deck = new CardDeck();

        // act
        human.ReceiveCard(new StandardCard(Suit.Clubs, Rank.King));

        CrazyEightsGame game = new CrazyEightsGame(deck, human, cpu, 0);

        // assert
        Assert.AreEqual("", game.GetWinner());
    }
}