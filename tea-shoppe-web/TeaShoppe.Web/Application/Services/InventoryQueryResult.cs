using TeaShoppe.Web.Application.Interfaces;
using TeaShoppe.Web.Domain.Inventory;
using TeaShoppe.Web.Domain.InventoryQuery;

namespace TeaShoppe.Web.Application.Services;

/// <summary>
/// Class to return the filtered inventory list and applied filters derived from InventoryQueryService. 
/// </summary>

public class InventoryQueryResult
{
    public IReadOnlyList<InventoryItem> Items { get; set; } = new List<InventoryItem>();
    public IReadOnlyList<string> AppliedFilters { get; set; } = new List<string>();
}
