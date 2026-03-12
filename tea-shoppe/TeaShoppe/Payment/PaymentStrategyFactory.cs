namespace TeaShoppe.Payment;

public class PaymentStrategyFactory
{
    private readonly Dictionary<string, IPaymentStrategy> _strategies = new();

    public PaymentStrategyFactory(TextReader input, TextWriter output)
    {
        _strategies.Add("credit", new CreditCard(input, output));
        _strategies.Add("apple", new ApplePay(input, output));
        _strategies.Add("crypto", new CryptoCurrency(input, output));
    }

    public IPaymentStrategy CreateStrategy(string type)
    {
        if (_strategies.ContainsKey(type))
        {
            return _strategies[type];
        }
        throw new ArgumentException($"Strategy {type} not found");
    }
}