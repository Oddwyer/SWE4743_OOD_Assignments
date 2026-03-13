using TeaShoppe.Web.Domain.Common;

namespace TeaShoppe.Web.Domain.Inventory;

// Stock item class for teas in inventory.
public class InventoryItem
{

    public string Name { get; }
    public Guid SkuId { get; }
    public int StockCount { get; private set; } = 0;
    public decimal RetailPrice { get; private set; }
    public bool InStock => StockCount > 0;
    public StarRating Rating { get; private set; }

    // Create inventory item.
    public InventoryItem(Guid skuId, string name, decimal price, int quantity, StarRating rating)
    {
        Name =  name;
        RetailPrice = price;
        Rating = rating;
        SkuId = skuId;
        StockCount = quantity;
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