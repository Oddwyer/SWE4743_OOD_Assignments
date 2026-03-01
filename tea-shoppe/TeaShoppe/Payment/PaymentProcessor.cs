using TeaShoppe.Orders;

namespace TeaShoppe.Payment;

public class PaymentProcessor
{
    private IPaymentStrategy _strategy;
    private static int _next = 100;
    private int _receiptNumber;

    public PaymentProcessor(IPaymentStrategy strategy)
    {
        _strategy = strategy;
    }
    
    public void Checkout(Order order)
    {
        if (_strategy.Pay(order.OrderTotal()))
        {
            order.OrderTotal();
            _receiptNumber = _next++;
        }

        order.OrderDetails();
        MakeReceipt();
    }

    private string MakeReceipt()
    {
        return $"""
                *** Purchase Complete ***
                Your package is on the way.
                Receipt Number: {_receiptNumber}
                """;
    }
    
    public void SetStrategy(IPaymentStrategy strategy)
    {
        _strategy = strategy;
    }
}