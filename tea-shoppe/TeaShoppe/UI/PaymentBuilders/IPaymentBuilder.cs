using TeaShoppe.Payment;

namespace tea_shoppe.UI.PaymentBuilders;

public interface IPaymentBuilder
{
    public IPaymentStrategy CreateStrategy(decimal amount);
}