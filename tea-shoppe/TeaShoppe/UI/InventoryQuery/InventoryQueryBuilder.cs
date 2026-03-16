using TeaShoppe.Decorators;
using TeaShoppe.Inventory;
using TeaShoppe.UI;

namespace tea_shoppe.UI.InventoryQuery;

/// <summary>
/// Builds query using decorator pattern and returns results.
/// </summary>

public class InventoryQueryBuilder
{
    
    public InventoryQueryBuilder()
    {
    }
    
    // Request an item from the shoppe and return results.
    public InventoryQueryOutput PerformQuery(RequestedItem requestedItem, IInventory currentRepo)
    {
        IInventory teaRepo = currentRepo;
        teaRepo = new TeaByName(teaRepo, requestedItem);
        teaRepo = new TeaByAvailability(teaRepo, requestedItem);
        teaRepo = new TeaByPrice(teaRepo, requestedItem);
        teaRepo = new TeaByRating(teaRepo, requestedItem);
        teaRepo = new TeaByQuantity(teaRepo, requestedItem);
        teaRepo = new SortTeas(teaRepo, requestedItem);
        
        InventoryQueryOutput output = new();
        return  output;
        
    }
}