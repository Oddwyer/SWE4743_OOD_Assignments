using CrazyEights.Game;
using CrazyEights.Players;
using CrazyEights.Deck;
using CrazyEights.Cards;
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
        ICard topDiscard = discardPile.TopDiscard();

        // act
        TurnContext context = new TurnContext(topDiscard, round, topDiscard.Suit );
        
        // assert
        Assert.AreEqual(1, context.RoundNumber);
        Assert.IsInstanceOfType(context, typeof(TurnContext));
        Assert.IsNotNull(context);
    }
}