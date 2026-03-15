using TeaShoppe.Web.Domain.Inventory;

namespace TeaShoppe.Web.Domain.Orders;

/// <summary>
/// Class representing each order item in customer order.
/// </summary>

public class OrderItem
{
    public string Name {get;}
    public Guid OrderItemId { get; }
    public int Quantity { get; private set; } = 0;
    public decimal Price { get; }

    public OrderItem(InventoryItem item, int requestedQuantity)
    {
        Name = item.Name;
        OrderItemId = item.InventoryItemId;
        Price = item.Price;
        Quantity = requestedQuantity;
    }

    // Increment quantity of order item.
    public void IncrementQuantity(int qty)
    {
        Quantity += qty;
    }

    // Decrement quantity of inventory item.
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