namespace TeaShoppe.Web.Domain.Payment;

/// <summary>
///  Apple Pay concrete strategy class.
/// </summary>
public class ApplePay : IPaymentStrategy
{
    
    public ApplePay()
    {

    }

    // Overriden Pay method.
    public bool Pay(decimal amount)
    {
        return true;
    }
}