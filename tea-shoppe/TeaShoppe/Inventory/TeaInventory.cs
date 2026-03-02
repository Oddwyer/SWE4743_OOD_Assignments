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
        if (_repositoryItems.Contains(item))
        {
            int index = _repositoryItems.IndexOf(item);
            _repositoryItems[index].IncrementStock(1);
        }
        else
        {
            _repositoryItems.Add(item);
        }
    }

    public void Remove(InventoryItem item)
    {
        if (_repositoryItems.Contains(item))
        {
            int index = _repositoryItems.IndexOf(item);
            _repositoryItems[index].DecrementStock(1);
        }
        
    }

    public IReadOnlyList<InventoryItem> GetInventory()
    {
       return _repositoryItems;
    }

    
}