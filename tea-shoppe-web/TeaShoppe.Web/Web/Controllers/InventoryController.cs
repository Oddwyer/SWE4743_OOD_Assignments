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
    
    // Provides blank query form.
    [HttpGet]
    public IActionResult Search()
    {
        var model = new InventorySearchViewModel();
        return View(model);
    }
    
    // Upon submission of the form, QueryItem is built, search is performed,
    // results are returned.
    [HttpPost]
    public IActionResult Search(InventorySearchViewModel model)
    {
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