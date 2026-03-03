namespace TeaShoppe.Orders;

/// <summary>
/// Class for customer order, holds multiple order items.
/// </summary>
/// 
public class Order
{
    private readonly List<OrderItem> _orderItems = new List<OrderItem>();
    private static int _next = 1;

    // Default constructor to initializes order. 
    public Order()
    {
        
    }
    // Constructor to begin order.
    public Order(OrderItem item)
    {
        item.ItemNumber = _next++;
        _orderItems.Add(item);
    }

    public void AddItem(OrderItem item)
    {
        int index = _orderItems.IndexOf(item);
        if (_orderItems.Contains(item))
        {
            _orderItems[index].IncrementQuantity();
        }
        else
        {
            _orderItems.Add(item);
        }
    }

    public void RemoveItem(OrderItem item)
    {
        int index = _orderItems.IndexOf(item);
        if (!_orderItems.Contains(item))
        {
            return;
        }
        if (_orderItems[index].Quantity > 1) 
        { 
            _orderItems[index].DecrementQuantity(); 
        }
        else 
        { 
            _orderItems.RemoveAt(index); 
        }
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
       string details = "Current Order:\n";
        foreach (OrderItem x in _orderItems)
        {
            details += $"{x.ItemId}: {x.Name} - Quantity: {x.Quantity}\n";
        }

        details += $"To Items: {TotalItemCount()}\n";
        details += $"Order Total: ${OrderTotal(): 0.00}\n";
        return details;
    }

    public bool SearchOrder(int itemId)
    {
        foreach (OrderItem x in _orderItems)
        {
            if (x.ItemId == itemId)
            {
                return true;
            }
        }
        return false;
    }
    
}