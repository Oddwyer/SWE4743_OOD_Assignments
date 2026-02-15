namespace TeaShoppe.Inventory;

public class RepositoryItem
{
    private static int _next;
    public int ItemId { get; }
    public string Name { get; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public StarRating Rating { get; private set; }

    public RepositoryItem(string name, decimal price, int qty, StarRating rating)
    {
        _next = 0;
        ItemId = _next++;
        Name = name;
        Price = price;
        Quantity = qty;
        Rating = rating;
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
        Price = newPrice;
    }
    
    public void UpdateRating(StarRating newRating)
    {
        Rating = newRating;
    }
}