using TeaShoppe.Inventory;
using TeaShoppe.UI;

namespace TeaShoppe.Decorators;

/// <summary>
/// Decorator class to search repository by tea name.
/// </summary>
public class TeaByName: InventoryQuery {
    private readonly string ? _name;
    
    public TeaByName(IInventory inner, RequestedItem item): base (inner)
    {
        _name = item.SearchName;    
    }

    public override IReadOnlyList<InventoryItem> GetInventory()
    {
        if (string.IsNullOrWhiteSpace(_name))
        {
            return inner.GetInventory();
        }
        else
        {
            return inner.GetInventory().Where(x => x.Name.Equals(_name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}