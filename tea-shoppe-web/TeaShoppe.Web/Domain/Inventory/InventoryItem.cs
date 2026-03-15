using TeaShoppe.Web.Domain.Common;

namespace TeaShoppe.Web.Domain.Inventory;

/// <summary>
/// Positional record "tea item" for each tea in inventory. Allows items to be immutable.
/// Changes require replacing the item in the inventory with a new record and updated properties.
/// </summary>

public record InventoryItem(
    Guid InventoryItemId,
    string Name,
    decimal Price,
    int Quantity,
    StarRating StarRating
);

