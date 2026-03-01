using TeaShoppe.Inventory;
using TeaShoppe.UI;

namespace TeaShoppe.Payment;

/// <summary>
/// Credit Card concrete strategy class.
/// </summary>
public class CreditCard : IPaymentStrategy
{
    private readonly TextReader _input;
    private readonly  TextWriter _output;

    public CreditCard(TextReader input, TextWriter output)
    {
        _input = input;
        _output = output;
    }
    public bool Pay(decimal amount)
    {
        string input;

        _output.WriteLine("\nEnter Credit Card Number: ");
        // Null handling
        input = _input.ReadLine() ?? "";
        if (!CardNumberValidator(input))
        {
            _output.WriteLine("Invalid card number. Must be 16 digits.\n");
            return false;
        }

       _output.WriteLine("Transaction Complete.");
        return true;
    }

    private bool CardNumberValidator(string input)
    {
        // Remove - and spaces from input. 
        string cleanInput = input.Replace(" ", "").Replace("-", "");

        // Must be all digits
        if (!cleanInput.All(char.IsDigit))
        {
            return false;
        }
        
        if(cleanInput.Length != 16)
        {
            return false;
        }

        return true;
    }
}