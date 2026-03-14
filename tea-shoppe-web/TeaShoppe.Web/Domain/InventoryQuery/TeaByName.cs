using TeaShoppe.Web.Domain.Inventory;

namespace TeaShoppe.Web.Domain.InventoryQuery;

/// <summary>
/// Decorator class to search inventory by tea name.
/// </summary>
/// 
public class TeaByName : InventoryQuery
{
    private readonly string? _name;

    public TeaByName(IInventory inner, RequestedItem item) : base(inner)
    {
        _name = item.SearchName;
    }

    // Overriden GetInventory method.
    public override IReadOnlyList<InventoryItem> GetInventory()
    {
        if (string.IsNullOrWhiteSpace(_name))
        {
            return inner.GetInventory();
        }

        return inner.GetInventory().Where(x => x.Name.Contains(_name, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}