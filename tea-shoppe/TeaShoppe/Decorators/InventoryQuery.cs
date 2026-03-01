using TeaShoppe.Inventory;

namespace TeaShoppe.Decorators;

/// <summary>
/// Implementation of decorator pattern for filter/sort decorators. This
/// is the abstract class for shared logic for all decorators and to house
/// the inner IRepository component.
/// </summary>
public abstract class InventoryQuery: IRepository
{
    protected IRepository inner; 

    public InventoryQuery(IRepository repository)
    {
        inner = repository;
    }

    public abstract IReadOnlyList<RepositoryItem> GetInventory();

}