using TeaShoppe.Inventory;

namespace TeaShoppe.Orders;

/// <summary>
/// Order Item class representing each order item in customer order.
/// </summary>

public class OrderItem
{
    public Tea Item { get; }
    public string Name => Item.Name;
    public int ItemId { get; }
    public int ItemNumber { get; set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    
    public OrderItem(RepositoryItem item, int qty)
    {
        ItemId = item.ItemId;
        Item = item.ShopItem;
        Price = item.RetailPrice;
        Quantity = qty;
    }
    
    public void IncrementQuantity()
    {
        Quantity++;
    }

    public void DecrementQuantity()
    {
        if (Quantity > 0)
        {
            Quantity--;
        }
    }
    
}