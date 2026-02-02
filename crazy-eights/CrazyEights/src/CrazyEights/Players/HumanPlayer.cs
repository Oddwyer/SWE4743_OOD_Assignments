using CrazyEights.Domain;
using CrazyEights.Game;
using CrazyEights.Cards;

namespace CrazyEights.Players;

public class HumanPlayer : PlayerBase
{
    // Needed Variables
    public override string Name { get; }
    private readonly CardHand hand;

    // Constructor
    public HumanPlayer(string name,  CardHand hand)
    {
        Name = name;
        this.hand = hand;
    }

    // Human Player Turn Actions
    public override TurnAction TakeTurn(TurnContext context)
    {
        hand.PrintHand(Name);
        bool draw = false;
        bool isWildCard = false;
        ICard discardedCard = new StandardCard(Suit.Diamonds, Rank.Ace);
        Suit wildCardSuit =  Suit.Clubs;   
            
        return new TurnAction(draw, discardedCard, wildCardSuit, isWildCard);
    }

    // Human Player Hand Count
    public override int HandCount()
    {
        return hand.Count();
    }

    // Human Player's Playable Cards
    public override IReadOnlyList<ICard> PlayableCards(TurnContext context)
    {
        return hand.PlayableCards(context);
    }

    // Human Player Add Card to Hand
    public override void ReceiveCard(ICard card)
    {
        hand.AddCard(card);
    }

    // Human Player Remove Card from Hand
    public override ICard RemoveCard(int index)
    {
        return new StandardCard(Suit.Clubs, Rank.Ace);
    }

    // View Hand
    public void ViewHand()
    {
        Console.WriteLine();
        hand.GetHand();
    }
}