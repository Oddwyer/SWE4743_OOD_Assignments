namespace TeaShoppe.Payment;

/// <summary>
/// Credit Card concrete strategy class.
/// </summary>
public class CreditCard : IPaymentStrategy
{
    
    public CreditCard()
    {
    }
    
    // Overriden Pay method.
    public bool Pay(decimal amount)
    {
        return true;
    }

}