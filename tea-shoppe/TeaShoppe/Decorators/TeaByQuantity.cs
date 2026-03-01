using TeaShoppe.Inventory;
using TeaShoppe.UI;

namespace TeaShoppe.Decorators;

// Decorator class to search repository by quantity. 

public class TeaByQuantity: InventoryQuery
{
    private readonly int ? _quantity;
    
    public TeaByQuantity(IRepository inner, RequestedItem item): base (inner)
    {
        _quantity = item.Quantity;    
    }

    public override IReadOnlyList<RepositoryItem> GetInventory()
    {
        return inner.GetInventory().Where(x => x.Quantity >= _quantity).ToList();
    }
}