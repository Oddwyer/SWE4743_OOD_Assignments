namespace TeaShoppe.Payment;

public class ApplePay : IPaymentStrategy
{
    public bool Pay(decimal amount)
    {
        Console.WriteLine($"\nProcessing Apple Pay for {amount}");
        Console.WriteLine("Apple Pay authorized.");
        return true;
    }
}