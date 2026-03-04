using TeaShoppe.Inventory;

namespace TeaShoppe.Orders;

/// <summary>
/// Order Item class representing each order item in customer order.
/// </summary>
public class OrderItem
{
    public Tea Item { get; }
    public string Name => Item.Name;
    public int SkuId { get; }
    public int ItemNumber { get; set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    public OrderItem(InventoryItem item)
    {
        SkuId = item.SkuId;
        Item = item.ShopItem;
        Price = item.RetailPrice;
        Quantity = 1;
    }

    public void IncrementQuantity(int qty)
    {
        Quantity += qty;
    }

    public void DecrementQuantity(int qty)
    {
        if (Quantity - qty < 0)
        {
            throw new InvalidOperationException("Quantity cannot go below zero.");
        }
        else{
            Quantity -= qty;
        }
    }
}