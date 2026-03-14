using TeaShoppe.Web.Domain.Inventory;

namespace TeaShoppe.Web.Domain.InventoryQuery;

/// <summary>
/// Concrete inventory class for tea shoppe inventory to serve as base for decorators.
/// Modification/search methods from TeaInventory in tea-shoppe console have been removed
/// in tea-shoppe-web version to introduce Singleton pattern: InventoryRepository which supplies
/// TeaInventory.
/// </summary>

public class TeaInventory : IInventory
{
    private readonly List<InventoryItem> _inventoryItems;

    public TeaInventory(IReadOnlyList<InventoryItem> items)
    {
        // .ToList() ensures a copy of the repository is generated to avoid changes to original seed repository.
        _inventoryItems = items.ToList();
    }
    
    // Return list of inventory items.
    public IReadOnlyList<InventoryItem> GetInventory()
    {
        return _inventoryItems.AsReadOnly();
    }

}