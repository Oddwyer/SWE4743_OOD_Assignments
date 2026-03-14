using TeaShoppe.Web.Domain.Inventory;

namespace TeaShoppe.Web.Application.Interfaces;

/// <summary>
/// Interface for singleton repository for in-memory inventory storage
/// and thread-safe quantity updates. 
/// </summary>

public interface IInventoryRepository
{

    // Remove specified quantity of select inventory item from inventory.
    public bool TryDecreaseQuantity(Guid sku, int quantity);

    // Return list of inventory items.
    public IReadOnlyList<InventoryItem> GetInventory();
    
    
}