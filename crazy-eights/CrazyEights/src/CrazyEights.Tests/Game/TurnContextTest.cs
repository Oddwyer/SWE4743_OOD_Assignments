using CrazyEights.Game;
using CrazyEights.Players;
using CrazyEights.Deck;
using JetBrains.Annotations;
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
        
        // act
        TurnContext context = new TurnContext(deck, discardPile, round);
        
        // assert
        Assert.AreEqual(1, context.RoundNumber);
        Assert.IsInstanceOfType(context, typeof(TurnContext));
        Assert.IsNotNull(context);
    }
}