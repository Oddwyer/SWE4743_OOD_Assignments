namespace TeaShoppe.Inventory;

public interface IRepository
{
   public IReadOnlyList<RepositoryItem> GetInventory();
}