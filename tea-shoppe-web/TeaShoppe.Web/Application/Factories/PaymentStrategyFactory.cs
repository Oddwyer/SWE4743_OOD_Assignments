using TeaShoppe.Web.Domain.Payment;

namespace TeaShoppe.Web.Application.Factories;

/// <summary>
/// Simple factory to handle selection logic and creation of proper payment
/// strategy based on payment type entered.
/// </summary>
public class PaymentStrategyFactory
{
    
    public PaymentStrategyFactory()
    {
    }

    public IPaymentStrategy CreateStrategy(string paymentType, string? cardNumber = null)
    {
        if (paymentType == "credit")
        {
            return new CreditCard(cardNumber);
        }

        if (paymentType == "apple")
        {
            return new ApplePay();
        }

        if (paymentType == "crypto")
        {
            return new CryptoCurrency();
        }

        throw new ArgumentException($"Strategy {paymentType} not found");
    }
}