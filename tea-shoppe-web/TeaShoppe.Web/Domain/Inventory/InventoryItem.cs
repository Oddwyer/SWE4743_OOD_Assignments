using TeaShoppe.Web.Domain.Common;

namespace TeaShoppe.Web.Domain.Inventory;

// Positional record "tea item" for each tea in inventory.

public record InventoryItem(
    Guid InventoryItemId,
    string Name,
    decimal Price,
    int Quantity,
    StarRating StarRating
);