namespace TeaShoppe.Inventory;

public class TeaInventory: IInventory
{
    private readonly List<InventoryItem> _repositoryItems;

    public TeaInventory(IReadOnlyList<InventoryItem> items)
    {
        // .ToList() ensures a copy of the catalog is made to avoid changes to original.
       _repositoryItems = items.ToList();
    }

    public void Add(InventoryItem item)
    {
        var existing = SearchInventory(item.Name);
        if (existing != null)
        {
            existing.IncrementStock(item.Quantity);
        }
        else
        {
            _repositoryItems.Add(item);
        }
    }

    public void Remove(InventoryItem item)
    {
        var existing = SearchInventory(item.Name);
        if (existing != null)
        {
            existing.DecrementStock(item.Quantity);
        }
    }

    public IReadOnlyList<InventoryItem> GetInventory()
    {
       return _repositoryItems;
    }
    
    public int InventoryCount => _repositoryItems.Count;
    
    public InventoryItem? SearchInventory(string teaName)
    {
        foreach (var x in _repositoryItems)
        {
            if (teaName == x.Name)
            {
                return x;
            }
        }
        return null;
    }
}