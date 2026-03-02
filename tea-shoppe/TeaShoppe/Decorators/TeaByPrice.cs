using TeaShoppe.Inventory;
using TeaShoppe.UI;

namespace TeaShoppe.Decorators;

/// <summary>
/// Decorator class to search by min/max pricing parameters. 
/// </summary>

public class TeaByPrice: InventoryQuery
{
    private readonly decimal ? _min;
    private readonly decimal ? _max;
    
    public TeaByPrice(IInventory inner, RequestedItem item): base (inner)
    {
        _min = item.MinPrice;
        _max = item.MaxPrice;
    }
    
    public override IReadOnlyList<InventoryItem> GetInventory()
    {
        return inner.GetInventory().Where(x => x.RetailPrice <= _max && x.RetailPrice >= _min).ToList();
    }
}
