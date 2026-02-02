using CrazyEights.Domain;
using CrazyEights.Cards;
using CrazyEights.Game;

namespace CrazyEights.Players;

public class CpuPlayer : PlayerBase
{
    // Needed Variables
    public override string Name { get; }
    private CardHand hand;
    private Suit[] suits = { Suit.Clubs, Suit.Diamonds, Suit.Hearts, Suit.Spades };

    // Constructor
    public CpuPlayer(string name, CardHand hand)
    {
        Name = name;
        this.hand = hand;
    }

    // CPU Turn Actions
    public override TurnAction TakeTurn(TurnContext context)
    {
        bool draw = false;
        bool isWildCard = false;
        ICard discardedCard = new StandardCard(Suit.Diamonds, Rank.Ace); // Dummy instantiation.
        Suit wildCardSuit = Suit.Clubs;

        var cards = hand.PlayableCards(context);
        if (cards.Count == 0)
        {
            draw = true;
        }
        else
        {
            hand.PlayableCards(context);
            Random rand =  new Random();
            var card =  cards[rand.Next(cards.Count)];
            
            Console.WriteLine($"{Name} selected {card.Rank} of {card.Suit} {CardIcons.GetSuitIcon(card.Suit)}\n");
            hand.RemoveCard(card);
            discardedCard = card;
            if (card.IsWildCard())
            {
                isWildCard = true;
                wildCardSuit = suits[rand.Next(suits.Length)];
            }
        }

        return new TurnAction(draw, discardedCard, wildCardSuit, isWildCard);
    }

    // CPU Hand Count
    public override int HandCount()
    {
        return hand.Count();
    }

    // CPU Add Card to Hand
    public override void ReceiveCard(ICard card)
    {
        hand.AddCard(card);
    }
}