using CrazyEights.Game;
using CrazyEights.Players;
using CrazyEights.Deck;
using JetBrains.Annotations;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrazyEights.Tests.Game;

[TestClass]
[TestSubject(typeof(TurnContext))]
public class TurnContextTest
{

    [TestMethod]
    public void TestTurnContextCreate()
    {
        // arrange 
        DiscardPile discardPile = new DiscardPile();
        CardDeck deck = new CardDeck();
        discardPile.DiscardCard(deck.DrawCard());
        int round = 1;
        IPlayer player1 = new HumanPlayer("Human");
        IPlayer player2 = new CpuPlayer("CPU");
        List<IPlayer> playerList = new List<IPlayer>();
        // act
        TurnContext context = new TurnContext(deck, discardPile, round, player1, playerList);
        
        // assert
        Assert.AreEqual(1, context.GetRoundNumber());
        Assert.IsInstanceOfType(context, typeof(TurnContext));
        Assert.IsNotNull(context);
    }
}