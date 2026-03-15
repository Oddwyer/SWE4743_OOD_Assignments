using TeaShoppe.Web.Application.Interfaces;
using TeaShoppe.Web.Domain.Inventory;
using TeaShoppe.Web.Domain.InventoryQuery;

namespace TeaShoppe.Web.Application.Services;

public class InventoryQueryService :  IInventoryQueryService
{

    private readonly IInventoryRepository _repository;

    public InventoryQueryService(IInventoryRepository repository)
    {
        _repository = repository;
    }
    
    
    
    // Provide InventoryQueryResult context object holding both
    // search results and applied filters.
    public InventoryQueryResult Search(QueryItem item)
    {
        InventoryQueryResult result = new InventoryQueryResult();
        result.Items = PerformQuery(item);
        result.AppliedFilters = AppliedFilters(item);
        return result;
    }

    //=================Helper Methods==================
    
    // Search repository for query item.
    private IReadOnlyList<InventoryItem> PerformQuery(QueryItem item)
    {
        IInventory teaRepo = new TeaInventory(_repository.GetInventory());
        teaRepo = new TeaByName(teaRepo, item);
        teaRepo = new TeaByAvailability(teaRepo, item);
        teaRepo = new TeaByPrice(teaRepo, item);
        teaRepo = new TeaByRating(teaRepo, item);
        teaRepo = new TeaByQuantity(teaRepo, item);
        teaRepo = new SortTeas(teaRepo, item);
        return teaRepo.GetInventory();
    }
    
    
    // Return applied filters using default logic.
    private IReadOnlyList<string> AppliedFilters(QueryItem item)
    {
        var lines = new List<string>();

        if (!string.IsNullOrWhiteSpace(item.SearchName))
            lines.Add($"Filter: Name contains \"{item.SearchName}\"");

        if (item.IsInStock == true)
            lines.Add("Filter: Availability = In Stock (Quantity > 0)");
        else if (item.IsInStock == false)
            lines.Add("Filter: Availability = Out of Stock");

        if (item.MinPrice != 0 || item.MaxPrice != 1000)
            lines.Add($"Filter: Price between ${item.MinPrice} and ${item.MaxPrice}");

        if (item.MinRating != 3 || item.MaxRating != 5)
            lines.Add($"Filter: Star rating between {item.MinRating} and {item.MaxRating}");

        if (item.Quantity > 0)
            lines.Add($"Filter: Minimum quantity {item.Quantity}");

        lines.Add($"Primary Sort: {item.Sort}");
        lines.Add($"Sort: Price ({item.PriceDirection.ToString()}");
        lines.Add($"Sort: Star Rating ({item.RatingDirection.ToString()})");

        return lines;
    }
}