namespace TeaShoppe.Web.Domain.Payment;

/// <summary>
/// CryptoCurrency concrete strategy class.
/// </summary>
public class CryptoCurrency : IPaymentStrategy
{

    public CryptoCurrency()
    {
    }

    // Overriden Pay method.
    public bool Pay(decimal amount)
    {
        return true;
    }
}