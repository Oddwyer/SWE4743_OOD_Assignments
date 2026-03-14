using TeaShoppe.Web.Domain.Inventory;

namespace TeaShoppe.Web.Domain.InventoryQuery;

/// <summary>
/// Concrete inventory class for tea shoppe inventory.
/// Modification/search methods from TeaInventory in tea-shoppe console
/// removed in tea-shoppe-web to introduce Singleton pattern: InventoryRepository.
/// </summary>

public class TeaInventory : IInventory
{
    private readonly List<InventoryItem> _inventoryItems;

    public TeaInventory(IReadOnlyList<InventoryItem> items)
    {
        // .ToList() ensures a copy of the catalog is generated to avoid changes to original seed catalog.
        _inventoryItems = items.ToList();
    }
    
    // Return list of inventory items.
    public IReadOnlyList<InventoryItem> GetInventory()
    {
        return _inventoryItems.AsReadOnly();
    }

}