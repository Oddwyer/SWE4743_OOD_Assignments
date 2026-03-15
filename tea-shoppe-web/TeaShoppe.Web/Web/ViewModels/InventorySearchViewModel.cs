using TeaShoppe.Web.Domain.Common;
using TeaShoppe.Web.Domain.Inventory;

namespace TeaShoppe.Web.Web.ViewModels;

/// <summary>
/// Mirroring data fields in QueryItem (servicing backend domain logic) this model class services the
/// frontend by collecting necessary data to pass to the backend for creating QueryItems, performing
/// queries, and returning query results.
/// </summary>

public class InventorySearchViewModel
{
    // Search inputs.
    public string? SearchName { get; set; }
    public int MinRating { get; set; } = 3;
    public int MaxRating { get; set; } = 5;
    public int? Quantity { get; set; } = 0;
    public decimal MinPrice { get; set; } = 0.00m;
    public decimal MaxPrice { get; set; } = 1000.00m;
    public PrimarySort Sort { get; set; } = PrimarySort.Price;
    public SortDirection PriceDirection { get; set; } = SortDirection.Ascending;
    public SortDirection RatingDirection { get; set; } = SortDirection.Descending;
    public bool? IsInStock { get; set; }
    public bool HasSearched { get; set; } = false;

    // Search outputs.
    public IReadOnlyList<InventoryItem> Items { get; set; } = new List<InventoryItem>();
    public IReadOnlyList<string> AppliedFilters { get; set; } = new List<string>();
}