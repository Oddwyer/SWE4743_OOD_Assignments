namespace TeaShoppe.Payment;

/// <summary>
///  Apple Pay concrete strategy class.
/// </summary>
public class ApplePay : IPaymentStrategy
{
    private readonly TextReader _input;
    private readonly TextWriter _output;

    public ApplePay(TextReader input, TextWriter output)
    {
        _input = input;
        _output = output;
    }

    // Overriden Pay method.
    public bool Pay(decimal amount)
    {
        _output.WriteLine($"\nProcessing Apple Pay for ${amount}");
        _output.WriteLine("Apple Pay authorized.");
        return true;
    }
}