using CrazyEights.Domain;
using CrazyEights.Game;
using CrazyEights.Cards;

namespace CrazyEights.Players;

public class HumanPlayer : PlayerBase
{
    public override string Name { get; }
    private readonly CardHand hand;

    public HumanPlayer(string name)
    {
        Name = name;
        hand = new CardHand();
    }

    public override TurnAction TakeTurn(TurnContext context)
    {
        Console.WriteLine();
        bool draw = false;
        bool isWildCard = false;
        ICard discardedCard = new StandardCard(Suit.Diamonds, Rank.Ace);
        Suit wildCardSuit =  Suit.Clubs;   
            
        return new TurnAction(draw, discardedCard, wildCardSuit, isWildCard);
    }

    public override int HandCount()
    {
        return hand.Count();
    }

    public override IReadOnlyList<ICard> PlayableCards(TurnContext context)
    {
        return hand.PlayableCards(context);
    }

    public override void ReceiveCard(ICard card)
    {
        hand.AddCard(card);
    }

    public override ICard RemoveCard(int index)
    {
        return new StandardCard(Suit.Clubs, Rank.Ace);
    }

    public void ViewHand()
    {
        Console.WriteLine();
        hand.ViewHand();
    }
}