using TeaShoppe.Inventory;
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
    private TextReader _input;
    private TextWriter _output;

    public PaymentProcessor(IPaymentStrategy strategy, TextReader input, TextWriter output)
    {
        Strategy = strategy;
        _input = input;
        _output = output;
    }
    
    // Process payment.
    public bool ProcessPayment(Order order)
    {
        if (Strategy.Pay(order.OrderTotal()))
        {
            _receiptNumber = _next++;
            string receipt = MakeReceipt(order, _receiptNumber);
            _output.WriteLine(receipt);
            return true;
        }
        _output.WriteLine("\nPayment failed. Please try again.");
        return false;
    }

    
    // Create receipt.
    private string MakeReceipt(Order order, int  receiptNumber)
    {
        return $"""
                *** Purchase Complete ***
                Your package is on the way.
                Receipt Number: {receiptNumber}
                
                Receipt Total ${order.OrderTotal()}
                
                **Thank you for shopping at Sweet Teas**
                """;
    }
    
    // Return payment strategy.
    public IPaymentStrategy GetStrategy =>  Strategy;
    
    // Update current strategy.
    public void SetStrategy(IPaymentStrategy strategy)
    {
        Strategy = strategy;
    }
}