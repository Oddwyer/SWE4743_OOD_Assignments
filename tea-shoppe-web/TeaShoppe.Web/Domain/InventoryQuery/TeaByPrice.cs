using TeaShoppe.Web.Domain.Inventory;

namespace TeaShoppe.Web.Domain.InventoryQuery;

/// <summary>
/// Decorator class to search inventory by min/max pricing parameters. 
/// </summary>

public class TeaByPrice: InventoryQuery
{
    private readonly decimal ? _min;
    private readonly decimal ? _max;
    
    public TeaByPrice(IInventory inner, QueryItem item): base (inner)
    {
        _min = item.MinPrice;
        _max = item.MaxPrice;
    }
    
    // Overriden GetInventory method.
    public override IReadOnlyList<InventoryItem> GetInventory()
    {
        return inner.GetInventory().Where(x => x.Price <= _max && x.Price >= _min).ToList();
    }
}
