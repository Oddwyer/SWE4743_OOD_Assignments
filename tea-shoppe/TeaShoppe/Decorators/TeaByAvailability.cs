using TeaShoppe.Inventory;

namespace TeaShoppe.Decorators;

/// <summary>
/// Decorator class to search inventory by availability. 
/// </summary>
public class TeaByAvailability : InventoryQuery
{
    private readonly bool? _inStock;

    public TeaByAvailability(IInventory inner, RequestedItem item) : base(inner)
    {
        _inStock = item.IsInStock;
    }

    public override IReadOnlyList<InventoryItem> GetInventory()
    {
        if (_inStock.HasValue)
        {
            return inner.GetInventory().Where(x => x.InStock == _inStock).ToList();
        }

        return inner.GetInventory();
    }
}