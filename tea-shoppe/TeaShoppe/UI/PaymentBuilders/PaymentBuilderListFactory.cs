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

    public IPaymentStrategy BuildPayment(string paymentType)
    {
        
        switch (paymentType)
        {
            case "apple":
                _builder = new ApplePayPaymentBuilder(_input,  _output);
                return new ApplePay();
            case "crypto":
                return new CryptoCurrencyPaymentBuilder(_output, _input);
            case "credit":
                return new CreditCardPaymentBuilder(_output, _input);
        }
        
    }
    
}