namespace TeaShoppe.Inventory;

/// <summary>
/// Concrete inventory class for tea shoppe inventory.
/// </summary>
public class TeaInventory : IInventory
{
    private readonly List<InventoryItem> _inventoryItems;

    public TeaInventory(IReadOnlyList<InventoryItem> items)
    {
        // .ToList() ensures a copy of the catalog is generated to avoid changes to original seed catalog.
        _inventoryItems = items.ToList();
    }

    // Add specified quantity of select inventory item to inventory.
    public void Add(InventoryItem item, int quantity)
    {
        InventoryItem? existing = SearchInventory(item.SkuId);
        if (existing != null)
        {
            existing.IncrementStock(quantity);
        }
        else
        {
            _inventoryItems.Add(item);
        }
    }

    // Remove specified quantity of select inventory item from inventory.
    public void Remove(InventoryItem item, int quantity)
    {
        InventoryItem? existing = SearchInventory(item.SkuId);
        if (existing == null)
        {
            return;
        }
        existing.DecrementStock(quantity);
    }

    // Return list of inventory items.
    public IReadOnlyList<InventoryItem> GetInventory()
    {
        return _inventoryItems;
    }

    // Return inventory count.
    public int InventoryCount => _inventoryItems.Count;

    // Search inventory by item's ID and return inventory item if it exists.
    public InventoryItem? SearchInventory(int skuId)
    {
        foreach (var x in _inventoryItems)
        {
            if (skuId == x.SkuId)
            {
                return x;
            }
        }

        return null;
    }
}