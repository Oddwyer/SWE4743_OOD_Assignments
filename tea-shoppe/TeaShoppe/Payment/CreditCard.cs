using TeaShoppe.UI;

namespace TeaShoppe.Payment;

/// <summary>
/// Credit Card concrete strategy class.
/// </summary>

public class CreditCard: IPaymentStrategy
{
    public bool Pay(decimal amount)
    {
        string input;
        
        Console.WriteLine("\nEnter Credit Card Number: ");
            // Null handling
            input = Console.ReadLine() ?? "";
            if (input.Length >= 16)
            {
                Console.WriteLine("Invalid card number. Must be 16 digits.\n");
                return false;
            }
        
        Console.WriteLine("Transaction Complete.");
        return true;
    }
}