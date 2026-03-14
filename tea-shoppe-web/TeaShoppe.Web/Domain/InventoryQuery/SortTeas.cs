using TeaShoppe.Web.Domain.Inventory;
using TeaShoppe.Web.Domain.Common;

namespace TeaShoppe.Web.Domain.InventoryQuery;

/// <summary>
/// Decorator class to sort search by price (ascending/descending) and/or rating (ascending/descending).
/// </summary>

public class SortTeas : InventoryQuery
{
    private readonly SortDirection _priceDirection = SortDirection.Ascending;
    private readonly SortDirection _ratingDirection = SortDirection.Descending;
    private readonly PrimarySort _sort;

    public SortTeas(IInventory inner, QueryItem item) : base(inner)
    {
        _priceDirection = item.PriceDirection;
        _ratingDirection = item.RatingDirection;
        _sort = item.Sort;
    }
    
    // Overidden GetInventory method.
    public override IReadOnlyList<InventoryItem> GetInventory()
    {
        // Temporary list to sort. 
        var currentOrder = inner.GetInventory();
            // If price requested first, sort list by price first, then rating. 
            if (_sort == PrimarySort.Price)
            {
                IOrderedEnumerable<InventoryItem> ordered = OrderByPrice(currentOrder, _priceDirection);
                ordered = ThenByRating(ordered, _ratingDirection);
                return ordered.ToList();
            }
            // If rating requested first, sort list by rating first, then price. 
            else
            {
                IOrderedEnumerable<InventoryItem> ordered = OrderByRating(currentOrder, _ratingDirection);
                ordered = ThenByPrice(ordered, _priceDirection);
                return ordered.ToList();
            }
    }

    // Helper methods for handling primary, secondary sorting preference as well as sorting direction. 
    private static IOrderedEnumerable<InventoryItem> OrderByPrice(IEnumerable<InventoryItem> items,
        SortDirection direction)
    {
        return direction == SortDirection.Ascending
            ? items.OrderBy(x => x.Price)
            : items.OrderByDescending(x => x.Price);
    }
    
    private static IOrderedEnumerable<InventoryItem> OrderByRating(IEnumerable<InventoryItem> items,
        SortDirection direction)
    {
        return direction == SortDirection.Ascending
            ? items.OrderBy(x => x.StarRating)
            : items.OrderByDescending(x => x.StarRating);
    }
    
    private static IOrderedEnumerable<InventoryItem> ThenByPrice(IOrderedEnumerable<InventoryItem> items,
        SortDirection direction)
    {
        return direction == SortDirection.Ascending
            ? items.ThenBy(x => x.Price)
            : items.ThenByDescending(x => x.Price);
    }
    
    private static IOrderedEnumerable<InventoryItem> ThenByRating(IOrderedEnumerable<InventoryItem> items,
        SortDirection direction)
    {
        return direction == SortDirection.Ascending
            ? items.ThenBy(x => x.StarRating)
            : items.ThenByDescending(x => x.StarRating);
    }
}

