using TeaShoppe.Web.Domain.Inventory;

namespace TeaShoppe.Web.Domain.InventoryQuery;

/// <summary>
/// Decorator class to search inventory by availability. 
/// </summary>
public class TeaByAvailability : InventoryQuery
{
    private readonly bool? _inStock;

    public TeaByAvailability(IInventory inner, QueryItem item) : base(inner)
    {
        _inStock = item.IsInStock;
    }

    // Overriden GetInventory method.
    public override IReadOnlyList<InventoryItem> GetInventory()
    {
        if (_inStock == true)
        {
            return inner.GetInventory().Where(x => x.Quantity > 0).ToList();
        }
        if (_inStock == false)
        {
            return inner.GetInventory().Where(x => x.Quantity <= 0).ToList();
        }

        return inner.GetInventory();
    }
}