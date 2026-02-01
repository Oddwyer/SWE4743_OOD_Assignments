using System;
using CrazyEights.Cards;
using CrazyEights.Deck;
using CrazyEights.Game;
using CrazyEights.Domain;
using CrazyEights.Players;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrazyEights.Tests.Cards;

[TestClass]
[TestSubject(typeof(CardHand))]
public class CardHandTest
{

    [TestMethod]
    public void TestCardHandCreate()
    {
        // arrange 
        CardDeck deck = new CardDeck();
        
        // act 
        CardHand hand = new CardHand(deck.DealCards(5));
        
        // assert
        Assert.IsNotNull(hand);
        Assert.AreEqual(5, hand.Count());
        
    }
    
    [TestMethod]
    public void TestPlayableCards()
    {
        // arrange 
        CardDeck deck = new CardDeck();
        List<ICard> testList = new List<ICard>();
        ICard card1 = new StandardCard(Suit.Clubs, Rank.Eight);
        ICard card2 = new StandardCard(Suit.Diamonds, Rank.Six);
        ICard card3 = new StandardCard(Suit.Hearts, Rank.Eight);
        ICard card4 = new StandardCard(Suit.Clubs, Rank.Ace);
        testList.Add(card2);
        testList.Add(card3);
        testList.Add(card4);
        CardHand hand =  new CardHand(testList);
        DiscardPile discardPile = new DiscardPile();
        discardPile.DiscardCard(card1);
        List<ICard> playList = new List<ICard>();
        playList.Add(card3);
        playList.Add(card4);
        int round = 3;
        IPlayer player1 = new HumanPlayer("Human");
        IPlayer player2 = new CpuPlayer("CPU");
        List<IPlayer> playerList = new List<IPlayer>();
        playerList.Add(player1);
        playerList.Add(player2);
        TurnContext context = new TurnContext(deck, discardPile, round, player1, playerList);
        
        // act 
        var result = hand.PlayableCards(context);
        
        // assert
        foreach (ICard card in result)
        {
            Console.WriteLine($"{card.Suit} {card.Rank}");
        }
    }
    
    [TestMethod]
    public void TestCardAddCard()
    {
        // arrange 
        CardDeck deck = new CardDeck();
        ICard card = deck.DrawCard();
        
        // act 
        CardHand hand = new CardHand(deck.DealCards(5));
        hand.AddCard(card);
        
        // assert
        Assert.IsNotNull(hand);
        Assert.AreEqual(6, hand.Count());
    }
    
    [TestMethod]
    public void TestCardRemoveCard()
    {
        // arrange 
        CardDeck deck = new CardDeck();
        ICard card = deck.DrawCard();
        
        // act 
        CardHand hand = new CardHand(deck.DealCards(5));
        ICard testCard = hand.RemoveCard(1);
        
        // assert
        Assert.IsNotNull(hand);
        Assert.AreEqual(4, hand.Count());
        Assert.IsNotNull(testCard);
    }
}