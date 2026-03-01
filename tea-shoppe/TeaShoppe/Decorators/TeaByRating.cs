using TeaShoppe.Inventory;

namespace TeaShoppe.Decorators;

// Decorator class to search by rating within a min and max range.
public class TeaByRating: InventoryQuery
{
    // Default values set. 
    private readonly int  _minRating;
    private readonly int  _maxRating;
    
    // TODO: Update param to Requested Item
    public TeaByRating(IRepository inner, int min, int max): base (inner)
    {
        _minRating = min;
        _maxRating = max;
    }

    public override IReadOnlyList<RepositoryItem> GetInventory()
    {
        return inner.GetInventory().Where(x => x.RatingValue <= _maxRating && x.RatingValue >= _minRating).ToList();
    }
}