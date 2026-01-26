using CrazyEights.Deck ;
using CrazyEights.Domain;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrazyEights.Tests.Deck;


[TestClass]
[TestSubject(typeof(CrazyEights.Deck.Deck))]
public class DeckTest
{

    [TestMethod]
    public void TestCreate()
    {
        // arrange
        var deck = new CrazyEights.Deck.Deck();

        // act
        

        // assert
        Assert.HasCount(52, deck.Cards);
        Assert.AreEqual(Suit.Clubs, deck.Cards[0].Suit);
        Assert.AreEqual(Rank.Two, deck.Cards[0].Rank);
        Assert.AreEqual(Suit.Diamonds, deck.Cards[13].Suit);
        Assert.AreEqual(Suit.Hearts, deck.Cards[26].Suit);
        Assert.AreEqual(Suit.Spades, deck.Cards[39].Suit);

    }
}