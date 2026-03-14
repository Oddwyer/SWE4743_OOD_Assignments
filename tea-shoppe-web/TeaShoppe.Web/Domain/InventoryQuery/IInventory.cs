using TeaShoppe.Web.Domain.Inventory;

namespace TeaShoppe.Web.Domain.InventoryQuery;

// Interface to be used for concrete components and decorators.
public interface IInventory
{
    public IReadOnlyList<InventoryItem> GetInventory();
}