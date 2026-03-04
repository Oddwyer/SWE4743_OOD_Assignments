using TeaShoppe.Domain;

namespace TeaShoppe.Inventory;


// In stock item of type tea for repository.
public class InventoryItem
{
    public Tea ShopItem { get; }
    public string Name => ShopItem.Name;
    public int SkuId { get; }
    public int StockCount { get; private set; }
    public decimal RetailPrice { get; private set; }
    public bool InStock => StockCount > 0;
    public StarRating Rating { get; private set; }

    // Create inventory item.
    public InventoryItem(Tea tea)
    {
        ShopItem = tea;
        RetailPrice = tea.Price;
        Rating = tea.Rating;
        SkuId = tea.SkuId;
        StockCount = 1;
    }
    
    // Create inventory item with stock quantity > 1. 
    public InventoryItem(Tea tea, int qty)
    {
        ShopItem = tea;
        RetailPrice = tea.Price;
        Rating = tea.Rating;
        SkuId = tea.SkuId;
        StockCount = qty;
    }

    // Increment quantity of inventory item.
    public void IncrementStock(int qty)
    {
        StockCount += qty;
    }

    // Decrement quantity of inventory item.
    public void DecrementStock(int qty)
    {
        if (StockCount - qty < 0)
        {
            throw new InvalidOperationException("Quantity cannot go below zero.");
        }
        else
        {
            StockCount -= qty;
        }
    }
    
    // Return rating as an integer.
    public int RatingValue => Rating.Rating;
    
    // Update retail price.
    public void UpdatePrice(decimal newPrice)
    {
       RetailPrice = newPrice;
    }
    
    // Update star rating. 
    public void UpdateRating(StarRating newRating)
    {
        Rating = newRating;
    }


}