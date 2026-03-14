using TeaShoppe.Web.Application.Services;
using TeaShoppe.Web.Domain.InventoryQuery;

namespace TeaShoppe.Web.Application.Interfaces;

/// <summary>
/// Interface for inventory query service honoring Dependency Inversion Principle;
/// high-level modules (UI controllers) depend on abstractions, not concrete implementations.
/// </summary>

public interface IInventoryQueryService
{
    // Search repository for query item.
    public InventoryQueryResult Search(QueryItem item);

}