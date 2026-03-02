using TeaShoppe.Domain;

namespace TeaShoppe.Inventory;


// In stock item of type tea for repository.
public class InventoryItem
{
    public Tea ShopItem { get; }
    public string Name => ShopItem.Name;
    private static int _next = 1;
    public int ItemId { get; }
    public int Quantity { get; private set; }
    public decimal RetailPrice { get; private set; }
    public bool InStock => Quantity > 0;
    public StarRating Rating { get; private set; }
    

    public InventoryItem(Tea tea, int qty)
    {
        ItemId = _next++;
        ShopItem = tea;
        RetailPrice = tea.Price;
        Quantity = qty;
        Rating = tea.Rating;
    }

    public void IncrementStock(int qty)
    {
        Quantity += qty;
    }

    public void DecrementStock(int qty)
    {
        if (Quantity - qty < 0)
        {
            throw new InvalidOperationException("Quantity cannot go below zero.");
        }
        else
        {
            Quantity -= qty;
        }
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