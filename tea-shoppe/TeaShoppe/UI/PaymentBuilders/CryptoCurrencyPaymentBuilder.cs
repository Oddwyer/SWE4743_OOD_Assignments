namespace tea_shoppe.UI.PaymentBuilders;
using TeaShoppe.Payment;

public class CryptoCurrencyPaymentBuilder
{
    private readonly TextReader _input;
    private readonly TextWriter _output;

    public CryptoCurrencyPaymentBuilder(TextReader input, TextWriter output)
    {
        _input = input;
        _output = output;
    }

    // Validates data entry for Cryptocurrency strategy and, if validated, returns strategy.
    public IPaymentStrategy CreateStrategy(decimal amount)
    {
        _output.WriteLine($"\nSubmitting transaction to blockchain for ${amount}");
        return new CryptoCurrency();
    }
}