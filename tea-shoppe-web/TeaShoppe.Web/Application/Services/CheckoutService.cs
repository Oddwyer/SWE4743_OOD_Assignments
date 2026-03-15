using TeaShoppe.Web.Application.Interfaces;
using TeaShoppe.Web.Domain.Orders;
using TeaShoppe.Web.Application.Factories;
using TeaShoppe.Web.Domain.Inventory;
using TeaShoppe.Web.Domain.Payment;

namespace TeaShoppe.Web.Application.Services;

/// <summary>
/// Facade pattern to handle checkout workflow.
/// </summary>
public class CheckoutService : ICheckoutService
{
    private readonly PaymentStrategyFactory _paymentStrategyFactory;
    private readonly IInventoryRepository _repository;
    
    public CheckoutService(PaymentStrategyFactory paymentStrategyFactory, IInventoryRepository repository)
    {
        _paymentStrategyFactory = paymentStrategyFactory;
        _repository = repository;
    }
    
    // Checkout method checks for valid quantity, payment details, and handles payment for purchase.
    public CheckoutResult Checkout(Guid selectedItemId, int selectedQuantity, string paymentType,
        string cardNumber)
    {
        InventoryItem item;
        
        Order currentOrder = new Order();
        try
        {
            item = ValidateQuantity(selectedItemId, selectedQuantity);
        }
        catch (ArgumentException error)
        {
            return CheckoutResult.Fail(error.Message);
        }

        try
        {
            IPaymentStrategy strategy = _paymentStrategyFactory.CreateStrategy(paymentType, cardNumber);
            OrderItem orderItem = new OrderItem(item, selectedQuantity);
            currentOrder.AddItem(orderItem);
            decimal total = currentOrder.OrderTotal();
            if (strategy.Pay(total))
            {
                if (_repository.TryDecreaseQuantity(selectedItemId, selectedQuantity))
                {
                    return CheckoutResult.Success(currentOrder, total);
                }

                return CheckoutResult.Fail("Item not available from inventory.");
            }
            return CheckoutResult.Fail("Payment failed.");
        }
        catch (ArgumentException)
        {
            return CheckoutResult.Fail("Invalid payment type.");
        }
    }

    // Private helper method to validate inventory quantity prior to payment process.
    private InventoryItem ValidateQuantity(Guid selectedItemId, int selectedQuantity)
    {
        if (selectedQuantity < 1)
        {
            throw new ArgumentException("Quantity must be greater than zero.");
        }

        var repo = _repository.GetInventory();
        var item = repo.FirstOrDefault(i => i.InventoryItemId == selectedItemId);

        if (item == null)
        {
            throw new ArgumentException("Item does not exist.");
        }

        if (item.Quantity >= selectedQuantity)
        {
            return item;
        }

        throw new ArgumentException("Quantity must be less than or equal to available quantity.");
    }
}