namespace TeaShoppe.Web.Domain.Payment;

/// <summary>
/// Credit Card concrete strategy class.
/// </summary>
public class CreditCard : IPaymentStrategy
{
    private string CardNumber { get; }

    public CreditCard(string cardNumber)
    {
        CardNumber = cardNumber;
    }
    
    // Overriden Pay method.
    public bool Pay(decimal amount)
    {
        
        if (!CardNumberValidator(CardNumber))
        {
            return false;
        }
        
        return true;
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