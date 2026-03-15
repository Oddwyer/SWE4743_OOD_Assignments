using TeaShoppe.Web.Application.Services;
using TeaShoppe.Web.Application.Factories;

namespace TeaShoppe.Web.Application.Interfaces;

public interface ICheckoutService
{
    public CheckoutResult Checkout(Guid selectedItemId, int selectedQuantity, string paymentType,
        string cardNumber);
}