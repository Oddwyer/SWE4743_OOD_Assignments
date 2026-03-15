namespace TeaShoppe.Web.Domain.Orders;

/// <summary>
/// Class for customer order; holds multiple order items.
/// </summary>

public class Order
{
    private readonly List<OrderItem> _orderItems = new();

    // Constructor to initializes order. 
    public Order()
    {
    }
    
    // Add items to order.
    public bool AddItem(OrderItem item)
    {
        OrderItem? existing = SearchOrder(item.OrderItemId);
        if (existing != null)
        {
            int before = existing.Quantity;
            existing.IncrementQuantity(item.Quantity);
            return existing.Quantity == before + item.Quantity;
        }

        item.IncrementQuantity(item.Quantity);
        _orderItems.Add(item);
        return _orderItems.Contains(item);
    }

    // Remove items from order.
    public bool RemoveItem(OrderItem item)
    {
        OrderItem? existing = SearchOrder(item.OrderItemId);
        int? count = existing.Quantity - item.Quantity;
        if (existing != null)
        {
            int before = existing.Quantity;
            if (existing.Quantity > item.Quantity)
            {
                existing.DecrementQuantity(item.Quantity);
                return existing.Quantity == before - item.Quantity;
            }

            _orderItems.Remove(existing);
            return !_orderItems.Contains(existing);
        }
        return false;
    }

    // Return order total cost. 
    public decimal OrderTotal()
    {
        decimal total = 0.00m;
        foreach (OrderItem x in _orderItems)
        {
            total += x.Price * x.Quantity;
        }

        return total;
    }
    
    // Return count of all items in order.
    public int TotalItemCount()
    {
        return _orderItems.Sum(x => x.Quantity);
    }
    
    // Return whether order is empty.
    public bool IsEmpty()
    {
        return _orderItems.Count == 0;
    }

    // Return number of line items on order. This number may differ from total count (note: number of items per line).
    public int NumberOfLineItems()
    {
        return _orderItems.Count;
    }

    // Return order details.
    public string OrderDetails()
    {
        if (!IsEmpty())
        {
            string details = "\nCurrent Order:\n";
            for (int i = 0; i < _orderItems.Count; i++)
            {
                details += $"{_orderItems[i].Name} - Quantity: {_orderItems[i].Quantity}\n";
            }

            details += $"Total Items: {TotalItemCount()}\n";
            details += $"Order Total: ${OrderTotal(): 0.00}\n";
            return details;
        }
        else
        {
            return "Your order is currently empty.";
        }
    }

    // Search order for specific item.
    public OrderItem? SearchOrder(Guid itemId)
    {
        foreach (OrderItem x in _orderItems)
        {
            if (x.OrderItemId == itemId)
            {
                return x;
            }
        }

        return null;
    }

    // Return item in order.
    public OrderItem GetItem(int index)
    {
        return  _orderItems[index];
    }
}