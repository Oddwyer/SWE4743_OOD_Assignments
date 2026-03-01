using TeaShoppe.Inventory;

namespace TeaShoppe.Decorators;

public abstract class InventoryQuery: IRepository
{
    protected IRepository inner; 

    public InventoryQuery(IRepository repository)
    {
        inner = repository;
    }

    public abstract IReadOnlyList<RepositoryItem> GetInventory();

}