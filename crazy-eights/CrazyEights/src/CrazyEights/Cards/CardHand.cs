namespace CrazyEights.Cards;

public class CardHand
{
    private List<ICard> playerHand = new List<ICard>();
    private List<ICard> playableCards = new List<ICard>();
    private int handCount = 0;
    
    public CardHand(ICard card)
    {
        playerHand.Add(card);
        handCount++;
    }
    
    public IReadOnlyList<ICard> ViewHand()
    {
        return playerHand;
    }
    
    public List<ICard> PlayableCards()
    {
        return playableCards;
    }

    public int HandCount()
    {
        return handCount;
    }
}