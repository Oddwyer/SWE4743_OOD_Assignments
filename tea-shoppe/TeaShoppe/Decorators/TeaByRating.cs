using TeaShoppe.Inventory;
using TeaShoppe.UI;

namespace TeaShoppe.Decorators;

// Decorator class to search by rating within a min and max range.
public class TeaByRating: InventoryQuery
{
    private readonly int ? _minRating;
    private readonly int ? _maxRating;
    
    public TeaByRating(IRepository inner, RequestedItem item): base (inner)
    {
        _minRating =item.MinRating;
        _maxRating = item.MaxRating;
    }

    public override IReadOnlyList<RepositoryItem> GetInventory()
    {
        return inner.GetInventory().Where(x => x.RatingValue <= _maxRating && x.RatingValue >= _minRating).ToList();
    }
}