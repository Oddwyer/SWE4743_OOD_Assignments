namespace TeaShoppe.Inventory;

public class TeaRepository: IRepository
{
    private readonly List<RepositoryItem> _repositoryItems;

    public TeaRepository(IReadOnlyList<RepositoryItem> items)
    {
        // .ToList() ensures a copy of the catalog is made to avoid changes to original.
       _repositoryItems = items.ToList();
    }

    public void Add(RepositoryItem item)
    {
        _repositoryItems.Add(item);
    }

    public void Remove(int itemId)
    {
        _repositoryItems.RemoveAt(itemId);
    }

    public IReadOnlyList<RepositoryItem> GetInventory()
    {
       return _repositoryItems;
    }

    
}