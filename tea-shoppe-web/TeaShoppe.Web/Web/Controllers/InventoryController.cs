using Microsoft.AspNetCore.Mvc;
using TeaShoppe.Web.Application.Interfaces;
using TeaShoppe.Web.Domain.InventoryQuery;
using TeaShoppe.Web.Web.ViewModels;

namespace TeaShoppe.Web.Web.Controllers;

/// <summary>
/// Controller for inventory to connect frontend query inputs to backend query logic
/// to perform and display queries.
/// </summary>
public class InventoryController : Controller
{
    private readonly IInventoryQueryService _queryService;

    public InventoryController(IInventoryQueryService queryService)
    {
        _queryService = queryService;
    }
    
    /// <summary>
    /// Displays the tea search form with default filter values.
    /// </summary>
    /// <returns>Search view with initial ViewModel.</returns>
    
    [HttpGet]
    public IActionResult Search()
    {
        var model = new InventorySearchViewModel();
        return View(model);
    }
    
    /// <summary>
    /// Processes the search form submission and applies filtering/sorting decorators.
    /// </summary>
    /// <param name="model">The search criteria submitted by the user.</param>
    /// <returns>Search view populated with filtering results and applied filter summaries.</returns>
    
    [HttpPost]
    public IActionResult Search(InventorySearchViewModel model)
    {
        if (model.MinPrice > model.MaxPrice)
        {
            ModelState.AddModelError("", "Minimum price cannot be greater than maximum price.");
        }

        if (model.MinRating > model.MaxRating)
        {
            ModelState.AddModelError("", "Minimum rating cannot be greater than maximum rating.");
        }

        if (model.Quantity < 0)
        {
            ModelState.AddModelError("", "Minimum quantity cannot be negative.");
        }

        if (!ModelState.IsValid)
        {
            model.HasSearched = false;
            return View(model);
        }
        var query = new QueryItem
        {
            SearchName = model.SearchName,
            MinRating = model.MinRating,
            MaxRating = model.MaxRating,
            Quantity = model.Quantity,
            MinPrice = model.MinPrice,
            MaxPrice = model.MaxPrice,
            Sort = model.Sort,
            PriceDirection = model.PriceDirection,
            RatingDirection = model.RatingDirection,
            IsInStock = model.IsInStock
        };

        var result = _queryService.Search(query);

        model.HasSearched = true;
        model.Items = result.Items;
        model.AppliedFilters = result.AppliedFilters;

        return View(model);
    }
}