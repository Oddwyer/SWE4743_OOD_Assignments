using CrazyEights.Game;
using CrazyEights.Domain;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrazyEights.Tests.Game;

[TestClass]
[TestSubject(typeof(TurnAction))]
public class TurnActionTest
{

    [TestMethod]
    public void TestTurnActionCreate()
    {
        // arrange 
        string action = "play";
        string action2 = "draw";
        int index = 2;
        int index2 = 3;
        Suit suit = Suit.Clubs;
        Suit suit2 = Suit.Diamonds;
        
        // act
        TurnAction turnAction = new TurnAction(action, index, suit);
        
        // assert 
        Assert.IsNotNull(turnAction);
        Assert.AreEqual(action, turnAction.ActionType);
        Assert.AreNotEqual(action2, turnAction.ActionType);
        Assert.AreEqual(index, turnAction.SelectedCardIndex);
        Assert.AreNotEqual(index2, turnAction.SelectedCardIndex);
        Assert.AreEqual(suit, turnAction.SelectedSuit);
        Assert.AreNotEqual(suit2, turnAction.SelectedSuit);
    }
}