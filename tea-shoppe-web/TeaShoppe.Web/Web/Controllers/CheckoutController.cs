using Microsoft.AspNetCore.Mvc;
using TeaShoppe.Web.Application.Interfaces;
using TeaShoppe.Web.Web.ViewModels;

namespace TeaShoppe.Web.Web.Controllers;

/// <summary>
/// Controller for checkout process to connect frontend checkout inputs to backend checkout logic
/// to perform and display checkout and purchase results.
/// </summary>
public class CheckoutController : Controller
{
    private readonly ICheckoutService _checkoutService;

    public CheckoutController(ICheckoutService checkoutService)
    {
        _checkoutService = checkoutService;
    }

    // Upon submission of the payment, Checkout is processed and
    // results are returned view PGR (POST-REDIRECT-GET).
    [HttpPost]
    public IActionResult Checkout(CheckoutViewModel model)
    {
        var result = _checkoutService.Checkout(model.SelectedItemId, model.SelectedQuantity, model.PaymentType,
            model.CardNumber);

        if (!result.Passed)
        {
            model.Success = false;
            model.Message = result.Message;
            return View(model);
        }
        TempData["Receipt"] = result.Message;

        return RedirectToAction("Receipt");
    }

    [HttpGet]
    public IActionResult Receipt()
    {
        var model = new CheckoutViewModel
        {
            Success = true,
            Message = TempData["Receipt"]?.ToString()
        };

        return View(model);
    }
}