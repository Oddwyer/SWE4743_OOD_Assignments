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

    // Upon submission of the payment, Checkout is processed and
    // results are returned.
    [HttpPost]
    public IActionResult Checkout(CheckoutViewModel model)
    {
        var result = _checkoutService.Checkout(model.SelectedItemId, model.SelectedQuantity, model.PaymentType,
            model.CardNumber);
            
        model.Success = result.Passed;
        model.Message = result.Message;

        return View(model);
    }
}