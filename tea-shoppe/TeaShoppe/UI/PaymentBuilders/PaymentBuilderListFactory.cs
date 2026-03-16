using tea_shoppe.UI.Builders;
using TeaShoppe.Payment;

namespace tea_shoppe.UI.PaymentBuilders;

public class PaymentBuilderListFactory
{
    private readonly TextWriter _output;
    private readonly TextReader _input;
    private IPaymentBuilder _builder;

    public PaymentBuilderListFactory(TextWriter output, TextReader input)
    {
        _output = output;
        _input = input;
    }

    public IPaymentStrategy BuildPayment(decimal amount, string paymentType)
    {
        switch (paymentType)
        {
            case "apple":
                return new ApplePayPaymentBuilder(_input, _output).CreateStrategy(amount);
            case "crypto":
                return new CryptoCurrencyPaymentBuilder(_input, _output).CreateStrategy(amount);
            case "credit":
                return new CreditCardPaymentBuilder(_input, _output).CreateStrategy(amount);
        }
    }
}