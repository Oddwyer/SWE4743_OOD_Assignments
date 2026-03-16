using tea_shoppe.UI.PaymentBuilders;
using TeaShoppe.Inventory;
using TeaShoppe.Orders;
using TeaShoppe.UI;

namespace TeaShoppe.Payment;

/// <summary>
/// Payment processing class for dynamic dispatching between payment
/// methods.
/// </summary>
public class PaymentProcessor
{
    private IPaymentStrategy Strategy { get; set; }
    private PaymentBuilderListFactory paymentBuilder;
    private static int _next = 100;
    private int _receiptNumber;
    private TextReader _input;
    private TextWriter _output;

    public PaymentProcessor(TextReader input, TextWriter output)
    {
        _input = input;
        _output = output;
        paymentBuilder = new PaymentBuilderListFactory(output, input);
    }
    
    // Process payment.
    public bool ProcessPayment(Order order, string paymentType)
    {
        Strategy = paymentBuilder.BuildPayment(paymentType);
        
        if (Strategy.Pay(order.OrderTotal()))
        {
            _output.WriteLine("Transaction Complete.");
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