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

    public void Remove(RepositoryItem item)
    {
        if (_repositoryItems.Contains(item))
        {
            int index = _repositoryItems.IndexOf(item);
            _repositoryItems[index].DecrementStock(1);
        }
        
    }

    public IReadOnlyList<RepositoryItem> GetInventory()
    {
       return _repositoryItems;
    }

    
}