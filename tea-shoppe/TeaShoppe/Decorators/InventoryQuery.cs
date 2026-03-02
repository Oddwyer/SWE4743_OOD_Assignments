using TeaShoppe.Inventory;

namespace TeaShoppe.Decorators;

/// <summary>
/// Implementation of decorator pattern for filter/sort decorators. This
/// is the abstract class for shared logic for all decorators and to house
/// the inner IRepository component.
/// </summary>
public abstract class InventoryQuery: IInventory
{
    protected IInventory inner; 

    public InventoryQuery(IInventory inventory)
    {
        inner = inventory;
    }

    public abstract IReadOnlyList<InventoryItem> GetInventory();

}