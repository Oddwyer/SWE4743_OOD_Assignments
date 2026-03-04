using TeaShoppe.Orders;

namespace TeaShoppe.Payment;

/// <summary>
/// Payment processing class for dynamic dispatching between payment
/// methods.
/// </summary>
public class PaymentProcessor
{
    private IPaymentStrategy Strategy { get; set; } 
    private static int _next = 100;
    private int _receiptNumber;

    public PaymentProcessor(IPaymentStrategy strategy)
    {
        Strategy = strategy;
    }
    
    public string ProcessPayment(Order order)
    {
        if (Strategy.Pay(order.OrderTotal()))
        {
            _receiptNumber = _next++;
            return MakeReceipt(order,  _receiptNumber);
        }
        return "\nPayment failed. Please try again.";
    }

    private string MakeReceipt(Order order, int receiptNumber)
    {
        return $"""
                *** Purchase Complete ***
                Your package is on the way.
                Receipt Number: {_receiptNumber}
                
                {order.OrderTotal()}
                """;
    }
    
    public IPaymentStrategy GetStrategy =>  Strategy;
    
    public void SetStrategy(IPaymentStrategy strategy)
    {
        Strategy = strategy;
    }
}