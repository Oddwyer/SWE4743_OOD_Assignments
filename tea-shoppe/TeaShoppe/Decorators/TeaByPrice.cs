using TeaShoppe.Inventory;

namespace TeaShoppe.Decorators;

// Decorator class to search by price within a min and max range. 
public class TeaByPrice: InventoryQuery
{
    private readonly decimal _min;
    private readonly decimal _max;
    
    // TODO: Update param to Requested Item
    public TeaByPrice(IRepository inner, decimal min, decimal max): base (inner)
    {
        _min = min;
        _max = max;
    }

    public override IReadOnlyList<RepositoryItem> GetInventory()
    {
        return inner.GetInventory().Where(x => x.RetailPrice <= _max && x.RetailPrice >= _min).ToList();
    }
}
