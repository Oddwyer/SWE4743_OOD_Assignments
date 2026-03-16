using TeaShoppe.Web.Domain.Inventory;

namespace TeaShoppe.Web.Domain.InventoryQuery;

/// <summary>
/// Decorator class to search inventory by min/max rating parameters.
/// </summary>
public class TeaByRating : InventoryQuery
{
    private readonly int? _minRating;
    private readonly int? _maxRating;

    public TeaByRating(IInventory inner, QueryItem item) : base(inner)
    {
        _minRating = item.MinRating;
        _maxRating = item.MaxRating;
    }

    // Overridden GetInventory method.
    public override IReadOnlyList<InventoryItem> GetInventory()
    {
        return inner.GetInventory().Where(x => x.StarRating.Rating <= _maxRating && x.StarRating.Rating >= _minRating).ToList();
    }
}