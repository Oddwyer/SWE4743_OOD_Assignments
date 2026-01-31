using CrazyEights.Deck;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrazyEights.Cards;

namespace CrazyEights.Tests.Deck;

[TestClass]
[TestSubject(typeof(DiscardPile))]
public class DiscardPileTest
{

    [TestMethod]
    public void TestDiscardPileCreate()
    {
        // arrange
        var deck = new CardDeck();
        DiscardPile discardPile = new DiscardPile();
        
        // act
        discardPile.DiscardCard(deck.DrawCard());
        
        // assert
        Assert.AreEqual(1, discardPile.DiscardCount());
    }
    
    [TestMethod]
    public void TestDiscardPilePeek()
    {
        // arrange
        var deck = new CardDeck();
        DiscardPile discardPile = new DiscardPile();
        ICard card1 = deck.DrawCard();
        ICard card2 = deck.DrawCard();    
        
        // act
        discardPile.DiscardCard(card1);
        
        // assert
        Assert.AreEqual(card1, discardPile.DiscardPeek());
        Assert.AreNotEqual(card2, discardPile.DiscardPeek());
    }
    
    [TestMethod]
    public void TestDiscardPileCount()
    {
        // arrange
        var deck = new CardDeck();
        DiscardPile discardPile = new DiscardPile();
        ICard card1 = deck.DrawCard();
        ICard card2 = deck.DrawCard();    
        
        // act
        discardPile.DiscardCard(card1);
        discardPile.DiscardCard(card2);
        
        // assert
        Assert.AreEqual(2, discardPile.DiscardCount());
      
    }
}