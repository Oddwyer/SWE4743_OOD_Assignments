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
    public HumanPlayer(string name, CardHand hand)
    {
        Name = name;
        this.hand = hand;
    }

    // Human Player Turn Actions
    public override TurnAction TakeTurn(TurnContext context)
    {
        int choice = 0;
        bool draw = false;
        bool isWildCard = false;
        ICard discardedCard = new StandardCard(Suit.Diamonds, Rank.Ace); // Stubbed for instantiation.
        Suit wildCardSuit = Suit.Clubs;

        var cards = PlayableCards(context);
        while (choice < cards.Count && choice >= 0 && cards.Count > 0)
        {
            hand.PrintHand(Name);
            Console.WriteLine();
            hand.PrintPlayableCards(Name, context.SuitToMatch);
            Console.Write("Choose a card number to play: ");

            // TryParse ? = If not null ant int; choice = int; else choice = 0.
            choice = int.TryParse(Console.ReadLine(), out choice) ? choice : 0;
            if (choice == 0)
            {
                Console.WriteLine("Invalid selection. Please try again. ");
            }
        }

        if (cards.Count == 0)
        {
            draw = true;
        }
        else
        {
            ICard card = cards[choice - 1];
            Console.WriteLine($"{Name} selected {card.Rank} of {card.Suit} {CardIcons.GetSuitIcon(card.Suit)}\n");
            hand.RemoveCard(card);
            discardedCard = card;
            if (card.IsWildCard())
            {
                isWildCard = true;
                wildCardSuit = ChooseSuit();
            }
            
        }

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
    
    private Suit ChooseSuit()
    {
        string suitOptions = $"""
                              {Name}, you played a wildcard! Choose a suit:
                                [H] Hearts
                                [D] Diamonds (current suit)
                                [C] Clubs
                                [S] Spades
                              """;
        Console.WriteLine(suitOptions);
        var validSelection = false;
        var selectedSuit = Suit.Clubs; // Dummy instantiation.
        while (!validSelection)
        {
            Console.Write("Enter the letter of your chosen suit: ");
            string suitChoice = Console.ReadLine();

            switch (suitChoice)
            {
                case "H":
                    validSelection = true;
                    selectedSuit = Suit.Hearts;
                    break;
                case "D":
                    validSelection = true;
                    selectedSuit = Suit.Diamonds;
                    break;
                case "C":
                    validSelection = true;
                    selectedSuit = Suit.Clubs;
                    break;
                case "S":
                    validSelection = true;
                    selectedSuit = Suit.Spades;
                    break;
            }

            Console.WriteLine("Invalid selection. Please try again. ");
        }

        return selectedSuit;
    }
}