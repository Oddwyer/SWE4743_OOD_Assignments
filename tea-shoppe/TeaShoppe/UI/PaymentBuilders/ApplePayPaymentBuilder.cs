using tea_shoppe.UI.PaymentBuilders;
using TeaShoppe.Payment;

namespace tea_shoppe.UI.Builders;

public class ApplePayPaymentBuilder: IPaymentBuilder
{
    private readonly TextReader _input;
    private readonly TextWriter _output;

    public ApplePayPaymentBuilder(TextReader input, TextWriter output)
    {
        _input = input;
        _output = output;
    }

    // Validates data entry for ApplePay strategy and, if validated, returns strategy.
    public IPaymentStrategy CreateStrategy(decimal amount)
    {
        _output.WriteLine($"\nProcessing Apple Pay for ${amount}");
        return new ApplePay();
    }
}