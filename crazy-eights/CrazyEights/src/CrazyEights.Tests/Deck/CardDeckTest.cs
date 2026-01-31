using CrazyEights.Deck;
using CrazyEights.Domain;
using CrazyEights.Cards;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CrazyEights.Tests.Deck;


[TestClass]
[TestSubject(typeof(CrazyEights.Deck.CardDeck))]
public class CardDeckTest
{

    [TestMethod]
    public void TestCreate()
    {
        // arrange
        var deck = new CrazyEights.Deck.CardDeck();

        // act
        
        // assert
        Assert.HasCount(52, deck.Cards);
        Assert.AreEqual(Suit.Clubs, deck.Cards[0].Suit);
        Assert.AreEqual(Rank.Two, deck.Cards[0].Rank);
        Assert.AreEqual(Suit.Diamonds, deck.Cards[13].Suit);
        Assert.AreEqual(Suit.Hearts, deck.Cards[26].Suit);
        Assert.AreEqual(Suit.Spades, deck.Cards[39].Suit);
        // Assert.IsTrue(deck.Cards[6].IsWildCard()); --> once shuffled, invalid test

    }

    [TestMethod]
    public void TestDeckRemaining()
    {
       var deck = new CrazyEights.Deck.CardDeck();

       int remaining = deck.DeckRemaining();
       
       Assert.AreEqual(52,  remaining);
    }
    
    [TestMethod]
    public void TestIsDeckEmpty()
    {
        var deck = new CrazyEights.Deck.CardDeck();

        bool isEmpty = deck.IsDeckEmpty();
       
        Assert.IsFalse(isEmpty);
    }
    
    [TestMethod]
    public void TestDrawCard()
    {
        var deck = new CrazyEights.Deck.CardDeck();

        var expectedCard = deck.Cards[0];
        var actualCard = deck.DrawCard();
        int remaining = deck.DeckRemaining();
        Assert.AreEqual(expectedCard,  actualCard);
        Assert.AreEqual(51, remaining);
    }
    
    [TestMethod]
    public void TestDealCards()
    {
        // arrange 
        var deck = new CrazyEights.Deck.CardDeck();
        
        // act
        List<ICard> testList = deck.DealCards(5);
        
        // assert
        Assert.AreEqual(5, testList.Count);
    }
}