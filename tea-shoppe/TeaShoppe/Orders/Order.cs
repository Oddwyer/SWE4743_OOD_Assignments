using TeaShoppe.UI;
using TeaShoppe.Inventory;

namespace TeaShoppe.Orders;

public class Order
{
    private readonly List<RepositoryItem> _orderItems = new List<RepositoryItem>();

    public Order(RepositoryItem orderItem)
    {
        _orderItems.Add(orderItem);
    }

    public void AddItem(RepositoryItem orderItem)
    {
        _orderItems.Add(orderItem);
    }
    
    public void RemoveItem(RepositoryItem orderItem)
    {
        _orderItems.Remove(orderItem);
    }

    public decimal OrderTotal()
    {
        decimal total = 0.00m;
        foreach (RepositoryItem x in _orderItems)
        {
            total += x.RetailPrice * x.Quantity;
        }  
        
        return total;
    }

    public int OrderCount()
    {
        return _orderItems.Count;
    }

    public void OrderDetails()
    {
        foreach (RepositoryItem x in _orderItems)
        {
            Console.WriteLine($"{x.Name} - Quantity: {x.Quantity}");
        }
    }
}