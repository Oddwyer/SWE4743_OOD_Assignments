namespace TeaShoppe.Payment;

/// <summary>
/// CryptoCurrency concrete strategy class.
/// </summary>
public class CryptoCurrency : IPaymentStrategy
{
    private readonly TextReader _input;
    private readonly TextWriter _output;

    public CryptoCurrency(TextReader input, TextWriter output)
    {
        _input = input;
        _output = output;
    }

    public bool Pay(decimal amount)
    {
        _output.WriteLine($"\nSubmitting transaction to blockchain for ${amount}");
        _output.WriteLine("Crypto payment confirmed.");
        return true;
    }
}