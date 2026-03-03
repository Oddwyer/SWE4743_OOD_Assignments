using TeaShoppe.Domain;

namespace TeaShoppe.Inventory;


// In stock item of type tea for repository.
public class InventoryItem
{
    public Tea ShopItem { get; }
    public string Name => ShopItem.Name;
    private static int _next = 1;
    public int ItemId { get; private set; }
    public int SkuId { get; }
    public int StockCount { get; private set; }
    public decimal RetailPrice { get; private set; }
    public bool InStock => StockCount > 0;
    public StarRating Rating { get; private set; }
    

    public InventoryItem(Tea tea)
    {
        ShopItem = tea;
        RetailPrice = tea.Price;
        Rating = tea.Rating;
        ItemId = _next++;
        SkuId = tea.SkuId;
        StockCount = 1;
    }
    
    public InventoryItem(Tea tea, int qty)
    {
        ShopItem = tea;
        RetailPrice = tea.Price;
        Rating = tea.Rating;
        ItemId = _next++;
        SkuId = tea.SkuId;
        StockCount = qty;
    }


    public void IncrementStock(int qty)
    {
        StockCount += qty;
    }

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

    public int RatingValue => Rating.Rating;
    
    public void UpdatePrice(decimal newPrice)
    {
       RetailPrice = newPrice;
    }
    
    public void UpdateRating(StarRating newRating)
    {
        Rating = newRating;
    }


}