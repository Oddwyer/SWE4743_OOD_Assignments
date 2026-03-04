using TeaShoppe.Inventory;
using TeaShoppe.UI;

namespace TeaShoppe.Decorators;

/// <summary>
/// Decorator class to search inventory by quantity. 
/// </summary>

public class TeaByQuantity: InventoryQuery
{
    private readonly int ? _quantity;
    
    public TeaByQuantity(IInventory inner, RequestedItem item): base (inner)
    {
        _quantity = item.Quantity;    
    }

    public override IReadOnlyList<InventoryItem> GetInventory()
    {
        return inner.GetInventory().Where(x => x.StockCount >= _quantity).ToList();
    }
}