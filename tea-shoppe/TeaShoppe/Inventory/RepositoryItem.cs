namespace TeaShoppe.Inventory;

// In stock item of type tea for repository.
public class RepositoryItem
{
    public Tea ShopItem { get; }
    public string Name => ShopItem.Name;
    private static int _next;
    public int ItemId { get; }
    public int Quantity { get; private set; }
    public decimal RetailPrice { get; private set; }
    public bool InStock => Quantity > 0;
    public StarRating Rating { get; private set; }
    

    public RepositoryItem(Tea tea, int qty)
    {
        _next = 0;
        ItemId = _next++;
        ShopItem = tea;
        RetailPrice = tea.Price;
        Quantity = qty;
        Rating = tea.Rating;
    }

    public void IncrementQuantity(int qty)
    {
        Quantity += qty;
    }

    public void DecrementQuantity(int qty)
    {
        Quantity -= qty;
    }

    public void UpdatePrice(decimal newPrice)
    {
       RetailPrice = newPrice;
    }
    
    public void UpdateRating(StarRating newRating)
    {
        Rating = newRating;
    }

    public int RatingValue => Rating.Rating;
}