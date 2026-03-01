namespace TeaShoppe.Payment;

/// <summary>
/// CryptoCurrency concrete strategy class.
/// </summary>
public class CryptoCurrency : IPaymentStrategy
{
    public bool Pay(decimal amount)
    {
        Console.WriteLine($"\nSubmitting transaction to blockchain for {amount}");
        Console.WriteLine("Crypto payment confirmed.");
        return true;
    }
}