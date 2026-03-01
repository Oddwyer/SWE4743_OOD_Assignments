using TeaShoppe.Inventory;

namespace TeaShoppe.Decorators;

// Decorator class to search repository by quantity. 

public class TeaByQuantity: InventoryQuery
{
    private readonly int _quantity;
    
    public TeaByQuantity(IRepository inner, int qty): base (inner)
    {
        _quantity = qty;    
    }

    public override IReadOnlyList<RepositoryItem> GetInventory()
    {
        return inner.GetInventory().Where(x => x.Quantity >= _quantity).ToList();
    }
}