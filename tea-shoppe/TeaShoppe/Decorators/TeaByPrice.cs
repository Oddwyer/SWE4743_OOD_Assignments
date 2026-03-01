using TeaShoppe.Inventory;
using TeaShoppe.UI;

namespace TeaShoppe.Decorators;

// Decorator class to search by price within a min and max range. 
public class TeaByPrice: InventoryQuery
{
    private readonly decimal ? _min;
    private readonly decimal ? _max;
    
    public TeaByPrice(IRepository inner, RequestedItem item): base (inner)
    {
        _min = item.MinPrice;
        _max = item.MaxPrice;
    }
    
    public override IReadOnlyList<RepositoryItem> GetInventory()
    {
        return inner.GetInventory().Where(x => x.RetailPrice <= _max && x.RetailPrice >= _min).ToList();
    }
}
