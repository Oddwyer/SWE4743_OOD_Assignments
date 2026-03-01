using TeaShoppe.Inventory;

namespace TeaShoppe.Decorators;

// Decorator class to search repository by availability. 
public class TeaByAvailability: InventoryQuery
{
    private readonly bool _inStock; 
    
    public TeaByAvailability(IRepository inner, bool inStock): base (inner)
    {
        _inStock = inStock;
    }

    public override IReadOnlyList<RepositoryItem> GetInventory()
    {
        return inner.GetInventory().Where(x => x.InStock == _inStock).ToList();
    }
}
