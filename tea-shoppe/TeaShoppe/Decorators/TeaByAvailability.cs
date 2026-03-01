using TeaShoppe.Inventory;
using TeaShoppe.UI;

namespace TeaShoppe.Decorators;

/// <summary>
/// Decorator class to search repository by availability. 
/// </summary>
 
public class TeaByAvailability: InventoryQuery
{
    private readonly bool ? _inStock; 
    
    public TeaByAvailability(IRepository inner, RequestedItem item): base (inner)
    {
        _inStock = item.IsInStock;
    }

    public override IReadOnlyList<RepositoryItem> GetInventory()
    {
        return inner.GetInventory().Where(x => x.InStock == _inStock).ToList();
    }
}
