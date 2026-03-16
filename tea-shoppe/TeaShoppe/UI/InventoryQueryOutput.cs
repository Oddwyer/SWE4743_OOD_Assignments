using TeaShoppe.Inventory;

namespace TeaShoppe.UI;

public class InventoryQueryOutput
{

    public InventoryQueryOutput()
    {
    }
    
    
    // Display results from query.
    public string DisplayQuery(IInventory query)
    {
        string results = QueryResults(query);
        return results;
    }
    
    
    // Helper method to build results.
    private string QueryResults(IInventory query)
    {
        string qty = "";
        var queryResults = query.GetInventory();
        string results = $"\n{queryResults.Count} items match your query:\n";
        int itemNumber = 1;
        foreach (var item in queryResults)
        {
            if (!item.InStock)
            {
                qty = "(OUT OF STOCK)";
            }
            else
            {
                qty = item.StockCount.ToString();
            }

            results += $"{itemNumber}. {item.Name,-15}\t${item.RetailPrice}\tQty: {qty,15}  {item.RatingValue} stars\n";
            itemNumber++;
        }

        return results;
    }

}