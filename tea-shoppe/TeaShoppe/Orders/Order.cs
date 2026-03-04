namespace TeaShoppe.Orders;

/// <summary>
/// Class for customer order; holds multiple order items.
/// </summary>
/// 
public class Order
{
    private readonly List<OrderItem> _orderItems = new List<OrderItem>();
    private static int _next = 1;

    // Constructor to initializes order. 
    public Order()
    {
    }

    // Constructor to begin order.
    public Order(OrderItem item, int qty)
    {
        item.ItemNumber = _next++;
        item.IncrementQuantity(qty);
        _orderItems.Add(item);
    }

    public bool AddItem(OrderItem item, int qty)
    {
        OrderItem? existing = SearchOrder(item.SkuId);
        if (existing != null)
        {
            int before = existing.Quantity;
            existing.IncrementQuantity(qty);
            return existing.Quantity == before + qty;
        }

        item.IncrementQuantity(qty);
        _orderItems.Add(item);
        return _orderItems.Contains(item);
    }

    public bool RemoveItem(OrderItem item, int qty)
    {
        OrderItem? existing = SearchOrder(item.SkuId);
        int? count = existing.Quantity - qty;
        if (existing != null)
        {
            int before = existing.Quantity;
            if (existing.Quantity > qty)
            {
                existing.DecrementQuantity(qty);
                return existing.Quantity == before - qty;
            }

            _orderItems.Remove(existing);
            return !_orderItems.Contains(existing);
        }
        return false;
    }

    public decimal OrderTotal()
    {
        decimal total = 0.00m;
        foreach (OrderItem x in _orderItems)
        {
            total += x.Price * x.Quantity;
        }

        return total;
    }

    public int TotalItemCount()
    {
        return _orderItems.Sum(x => x.Quantity);
    }

    public bool isEmpty()
    {
        return _orderItems.Count == 0;
    }


    public int NumberOfLineItems()
    {
        return _orderItems.Count;
    }

    public string OrderDetails()
    {
        if (!isEmpty())
        {
            string details = "\nCurrent Order:\n";
            for (int i = 0; i < _orderItems.Count; i++)
            {
                details += $"{i+1}: {_orderItems[i].Name} - Quantity: {_orderItems[i].Quantity}\n";
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

    public OrderItem? SearchOrder(int skuId)
    {
        foreach (OrderItem x in _orderItems)
        {
            if (x.SkuId == skuId)
            {
                return x;
            }
        }

        return null;
    }
}