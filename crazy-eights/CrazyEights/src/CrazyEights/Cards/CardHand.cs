using CrazyEights.Domain;
using CrazyEights.Game;

namespace CrazyEights.Cards;

public class CardHand
{
    // Needed Variables
    private readonly List<ICard> hand;
    private readonly List<ICard> playableCards;
    
    // Constructor
    public CardHand(List<ICard> cards)
    {
        hand = cards;
        playableCards = new List<ICard>();
    }

    // Get Hand
    public IReadOnlyList<ICard> GetHand()
    {
        return hand.AsReadOnly();
    }

    // Print Hand
    public void PrintHand(string name)
    {
        Console.WriteLine($"{name}'s hand");
        foreach (var card in hand)
        {
            string icon = CardIcons.GetSuitIcon(card.Suit);
            Console.WriteLine($"  - {card.Rank} of {card.Suit} {icon}");
        }
    }

    // Print Playable Cards
    public void PrintPlayableCards(string name, Suit suitToMatch, Rank rankToMatch)
    {
        Console.WriteLine($"{name}'s playable cards");
        for (int i = 0; i < playableCards.Count; i++)
        {
            var card = playableCards[i];
            string icon = CardIcons.GetSuitIcon(card.Suit);
            if (card.Rank == Rank.Eight)
            {
                Console.WriteLine($"  [{i + 1}] {card.Rank} of {card.Suit} {icon} (Wildcard!)");
            }
            else if(card.Suit == suitToMatch)
            {
                Console.WriteLine($"  [{i + 1}] {card.Rank} of {card.Suit} {icon} (Matches Suit)");
            }
            else if (card.Rank == rankToMatch)
            {
                Console.WriteLine($"  [{i + 1}] {card.Rank} of {card.Suit} {icon} (Matches Rank)");
            }
        }
    }

    // Create List of Playable Cards in Hand
    public IReadOnlyList<ICard> PlayableCards(TurnContext context)
    {
        playableCards.Clear();
        if (context.MustMatchSuit)
        {
            foreach (var card in hand)
            {
                if (card.Suit == context.DeclaredSuit)
                {
                    playableCards.Add(card);
                }
            }
        }
        else
        {
            foreach (var card in hand)
            {
                if (card.IsWildCard())
                {
                    playableCards.Add(card);
                }
                else if (card.Suit == context.TopDiscard.Suit)
                {
                    playableCards.Add(card);
                }
                else if (card.Rank == context.TopDiscard.Rank)
                {
                    playableCards.Add(card);
                }
            }
        }

        return playableCards.AsReadOnly();
    }

    // Return Hand Count
    public int Count()
    {
        return hand.Count;
    }

    // Add Card to Hand
    public void AddCard(ICard card)
    {
        hand.Add(card);
    }

    // Remove Card from Hand
    public void RemoveCard(ICard cardToRemove)
    {
        for (int i = 0; i < hand.Count; i++)
        {
            if (cardToRemove == hand[i])
            {
                hand.RemoveAt(i);
            }
        }
    }
}