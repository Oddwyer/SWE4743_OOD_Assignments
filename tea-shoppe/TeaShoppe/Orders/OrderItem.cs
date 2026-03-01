using TeaShoppe.Inventory;

namespace TeaShoppe.Orders;

public class OrderItem
{
    public Tea OrderItem { get; }
    public string Name => OrderItem.Name;
    private static int _next;
    public int ItemId { get; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    
    public OrderItem(RepositoryItem item, int qty)
    {
        _next = 0;
        ItemId = _next++;
        OrderItem = item.ShopItem;
        Price = item.RetailPrice;
        Quantity = qty;
    }
    
}