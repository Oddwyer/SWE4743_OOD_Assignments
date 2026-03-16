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

    /// <summary>
    /// Upon submission of the payment, Checkout is processed and results are returned view PRG (POST-REDIRECT-GET).
    /// The PRG pattern prevents duplicate form submissions and provides a smoother user experience after a successful
    /// data-modifying operation (like a purchase or a logout).
    /// </summary>
   
    [HttpPost]
    public IActionResult Checkout(CheckoutViewModel model)
    {
        var result = _checkoutService.Checkout(model.SelectedItemId, model.SelectedQuantity, model.PaymentType,
            model.CardNumber);

        var paymentLabel = model.PaymentType switch
        {
            "apple" => "ApplePay",
            "credit" => "CreditCard",
            "crypto" => "CryptoCurrency",
            _ => "Unknown"
        };
        
        TempData["Success"] = result.Passed;
        TempData["Receipt"] = result.Message;
        TempData["PaymentLabel"] = paymentLabel;

        return RedirectToAction(nameof(Receipt));
    }

    /// <summary>
    /// Displays the receipt view after a successful checkout.
    /// This is the "GET" part of the Post-Redirect-Get pattern.
    /// </summary>
    [HttpGet]
    public IActionResult Receipt()
    {
        
        var model = new CheckoutViewModel
        {
            Success = bool.TryParse(TempData["Success"]?.ToString(), out var success) && success,
            Message = TempData["Receipt"]?.ToString(),
            PaymentType = TempData["PaymentLabel"]?.ToString()
        };

        return View("Receipt", model);
    }
}