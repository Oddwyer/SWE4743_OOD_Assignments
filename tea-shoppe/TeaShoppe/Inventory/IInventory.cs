namespace TeaShoppe.Inventory;

// Interface to be used for concrete component and decorators.
public interface IInventory
{
   public IReadOnlyList<InventoryItem> GetInventory();
}