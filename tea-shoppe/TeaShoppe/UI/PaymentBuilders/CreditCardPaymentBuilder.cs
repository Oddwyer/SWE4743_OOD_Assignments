using TeaShoppe.Payment;
using tea_shoppe.UI.PaymentBuilders;

namespace tea_shoppe.UI.Builders;

public class CreditCardPaymentBuilder : IPaymentBuilder
{
    private readonly TextReader _input;
    private readonly TextWriter _output;

    public CreditCardPaymentBuilder(TextReader input, TextWriter output)
    {
        _input = input;
        _output = output;
    }

    // Validates data entry for Credit Card strategy and, if validated, returns strategy.
    public IPaymentStrategy CreateStrategy(decimal amount)
    {
        string input;

        _output.Write("\nEnter Credit Card Number: ");
        // Null handling
        input = _input.ReadLine() ?? "";
        if (!CardNumberValidator(input))
        {
            throw new InvalidOperationException("Invalid card number. Must be 16 digits.");
        }
        return new CreditCard();
    }
    

    // Strips and validates credit card number entry = 16 digits only.
    private bool CardNumberValidator(string input)
    {
        // Remove - and spaces from input. 
        string cleanInput = input.Replace(" ", "").Replace("-", "");

        // Must be all digits.
        if (!cleanInput.All(char.IsDigit))
        {
            return false;
        }

        if (cleanInput.Length != 16)
        {
            return false;
        }

        return true;
    }

}