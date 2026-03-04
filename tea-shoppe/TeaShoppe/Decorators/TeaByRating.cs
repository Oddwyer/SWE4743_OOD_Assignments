using TeaShoppe.Inventory;
using TeaShoppe.UI;

namespace TeaShoppe.Decorators;

/// <summary>
/// Decorator class to search inventory by min/max rating parameters.
/// </summary>

public class TeaByRating: InventoryQuery
{
    private readonly int ? _minRating;
    private readonly int ? _maxRating;
    
    public TeaByRating(IInventory inner, RequestedItem item): base (inner)
    {
        _minRating =item.MinRating;
        _maxRating = item.MaxRating;
    }

    public override IReadOnlyList<InventoryItem> GetInventory()
    {
        return inner.GetInventory().Where(x => x.RatingValue <= _maxRating && x.RatingValue >= _minRating).ToList();
    }
}