using System.Collections.Generic;
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
        IPlayer human = new HumanPlayer("You", new CardHand(new List<ICard>()));
        IPlayer cpu = new CpuPlayer("CPU", new CardHand(new List<ICard>()));

        CardDeck deck = new CardDeck();
        CrazyEightsGame game = new CrazyEightsGame(deck, human, cpu);

        Assert.AreEqual(51, deck.DeckRemaining());
        Assert.IsNotNull(game);
        Assert.IsInstanceOfType(game, typeof(CrazyEightsGame));
        Assert.AreEqual(2, game.players.Count);
    }

    [TestMethod]
    public void TestGameOverCPU()
    {
        // arrange
        HumanPlayer human = new HumanPlayer("You", new CardHand(new List<ICard>()));
        CpuPlayer cpu = new CpuPlayer("CPU", new CardHand(new List<ICard>()));
        CardDeck deck = new CardDeck();

        // act
        human.ReceiveCard(new StandardCard(Suit.Clubs, Rank.Ace));
        human.ReceiveCard(new StandardCard(Suit.Clubs, Rank.King));
        cpu.ReceiveCard(new StandardCard(Suit.Clubs, Rank.Ace));
        
        CrazyEightsGame game = new CrazyEightsGame(deck, human, cpu);
        while (!deck.IsDeckEmpty() && deck.DeckRemaining() > 0)
        {
            deck.DrawCard();
        }

        // assert
        Assert.AreEqual("CPU", game.GetWinner());
    }

    [TestMethod]
    public void TestGameOverHuman()
    {
        // arrange
        HumanPlayer human = new HumanPlayer("You", new CardHand(new List<ICard>()));
        CpuPlayer cpu = new CpuPlayer("CPU",new CardHand(new List<ICard>()));
        CardDeck deck = new CardDeck();

        // act
        human.ReceiveCard(new StandardCard(Suit.Clubs, Rank.Ace));
        cpu.ReceiveCard(new StandardCard(Suit.Clubs, Rank.King));
        cpu.ReceiveCard(new StandardCard(Suit.Clubs, Rank.Ace));
        
        CrazyEightsGame game = new CrazyEightsGame(deck, human, cpu);
        while (!deck.IsDeckEmpty() && deck.DeckRemaining() > 0)
        {
            deck.DrawCard();
        }

        // assert
        Assert.AreEqual("You", game.GetWinner());
    }

    [TestMethod]
    public void TestGameOverTie()
    {
        // arrange
        HumanPlayer human = new HumanPlayer("You", new CardHand(new List<ICard>()));
        CpuPlayer cpu = new CpuPlayer("CPU", new CardHand(new List<ICard>()));
        CardDeck deck = new CardDeck();

        // act
        human.ReceiveCard(new StandardCard(Suit.Clubs, Rank.Ace));
        cpu.ReceiveCard(new StandardCard(Suit.Clubs, Rank.King));
        
        CrazyEightsGame game = new CrazyEightsGame(deck, human, cpu);
        while (!deck.IsDeckEmpty() && deck.DeckRemaining() > 0)
        {
            deck.DrawCard();
        }

        // assert
        Assert.AreEqual("It's a tie game!", game.GetWinner());
    }

    [TestMethod]
    public void TestGameOverZeroHuman()
    {
        // arrange
        HumanPlayer human = new HumanPlayer("You", new CardHand(new List<ICard>()));
        CpuPlayer cpu = new CpuPlayer("CPU", new CardHand(new List<ICard>()));
        CardDeck deck = new CardDeck();

        // act
        cpu.ReceiveCard(new StandardCard(Suit.Clubs, Rank.King));
        
        CrazyEightsGame game = new CrazyEightsGame(deck, human, cpu);
        while (!deck.IsDeckEmpty() && deck.DeckRemaining() > 0)
        {
            deck.DrawCard();
        }

        // assert
        Assert.AreEqual("You", game.GetWinner());
    }

    [TestMethod]
    public void TestGameOverNotEmptyDeck()
    {
        // arrange
        HumanPlayer human = new HumanPlayer("You", new CardHand(new List<ICard>()));
        CpuPlayer cpu = new CpuPlayer("CPU", new CardHand(new List<ICard>()));
        CardDeck deck = new CardDeck();

        // act
        human.ReceiveCard(new StandardCard(Suit.Clubs, Rank.King));

        CrazyEightsGame game = new CrazyEightsGame(deck, human, cpu);

        // assert
        Assert.AreEqual("", game.GetWinner());
    }
}