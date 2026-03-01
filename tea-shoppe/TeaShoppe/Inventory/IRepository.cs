namespace TeaShoppe.Inventory;

// Interface to be used for concrete component and decorators.
public interface IRepository
{
   public IReadOnlyList<RepositoryItem> GetInventory();
}