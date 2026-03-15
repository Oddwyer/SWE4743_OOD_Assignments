using TeaShoppe.Web.Application.Interfaces;
using TeaShoppe.Web.Domain.Orders;
using TeaShoppe.Web.Application.Factories;

namespace TeaShoppe.Web.Application.Services;

public class CheckoutService
{
    PaymentStrategyFactory _paymentStrategyFactory;

    public CheckoutService(PaymentStrategyFactory paymentStrategyFactory)
    {
        _paymentStrategyFactory = paymentStrategyFactory;
    }

    private bool ValidateQuantity(OrderItem item)
    {
        
    }
}