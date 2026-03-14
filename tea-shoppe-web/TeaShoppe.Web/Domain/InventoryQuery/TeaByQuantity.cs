using TeaShoppe.Web.Domain.Inventory;

namespace TeaShoppe.Web.Domain.InventoryQuery;

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

    // Overriden GetInventory method.
    public override IReadOnlyList<InventoryItem> GetInventory()
    {
        return inner.GetInventory().Where(x => x.Quantity >= _quantity).ToList();
    }
}