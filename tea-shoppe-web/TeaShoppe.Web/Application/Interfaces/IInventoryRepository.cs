using TeaShoppe.Web.Domain.Inventory;

namespace TeaShoppe.Web.Application.Interfaces;

public interface IInventoryRepository
{

    // Remove specified quantity of select inventory item from inventory.
    public bool TryDecreaseQuantity(Guid sku, int quantity);

    // Return list of inventory items.
    public IReadOnlyList<InventoryItem> GetInventory();
    
    
}