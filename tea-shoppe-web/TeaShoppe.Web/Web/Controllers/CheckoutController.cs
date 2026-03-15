using Microsoft.AspNetCore.Mvc;
using TeaShoppe.Web.Application.Interfaces;
using TeaShoppe.Web.Web.ViewModels;

namespace TeaShoppe.Web.Web.Controllers;

public class CheckoutController : Controller
{
    private readonly ICheckoutService _checkoutService;

    public CheckoutController(ICheckoutService checkoutService)
    {
        _checkoutService = checkoutService;
    }

    // Provides blank query form.
    [HttpGet]
    public IActionResult Search()
    {
        var model = new CheckoutViewModel();
        return View(model);
    }

    // Upon submission of the payment, Checkout is processed and
    // results are returned.
    [HttpPost]
    public IActionResult Checkout(CheckoutViewModel model)
    {
        
        var result = _checkoutService.Checkout(model.SelectedItemId, model.SelectedQuantity, model.PaymentType,
            model.CardNumber);
            
        model.Success = result.Passed;
        model.Order = result.Order;
        model.Message = result.Message;

        return View(model);
    }
}