namespace TeaShoppe.Web.Domain.Inventory;

// Interface to be used for concrete components and decorators.
public interface IInventory
{
    public IReadOnlyList<InventoryItem> GetInventory();
}