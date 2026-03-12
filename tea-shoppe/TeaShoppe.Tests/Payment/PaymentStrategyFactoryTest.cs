using System.Diagnostics.CodeAnalysis;
using System.IO;
using JetBrains.Annotations;
using TeaShoppe.Payment;
using Xunit;

namespace tea_shoppe.Tests.Payment;

[TestSubject(typeof(PaymentStrategyFactory))]
public class PaymentStrategyFactoryTest
{
    [Fact]
    public void CreateStrategy_WhenApplePassedType_ShouldReturnApplePayStrategy()
    {
        // arrange
        TextReader reader = new StringReader("apple");
        TextWriter writer = new StringWriter();
        PaymentStrategyFactory testFactory = new PaymentStrategyFactory(reader, writer);

        // act
        IPaymentStrategy actual = testFactory.CreateStrategy("apple");

        // assert
        Assert.IsType<ApplePay>(actual);
    }
    
    [Fact]
    public void CreateStrategy_WhenCreditPassedType_ShouldReturnCreditCardStrategy()
    {
        // arrange
        TextReader reader = new StringReader("credit");
        TextWriter writer = new StringWriter();
        PaymentStrategyFactory testFactory = new PaymentStrategyFactory(reader, writer);

        // act
        IPaymentStrategy actual = testFactory.CreateStrategy("credit");

        // assert
        Assert.IsType<CreditCard>(actual);
    }
    
    [Fact]
    public void CreateStrategy_WhenCryptoPassedType_ShouldReturnCryptoStrategy()
    {
        // arrange
        TextReader reader = new StringReader("crypto");
        TextWriter writer = new StringWriter();
        PaymentStrategyFactory testFactory = new PaymentStrategyFactory(reader, writer);

        // act
        IPaymentStrategy actual = testFactory.CreateStrategy("crypto");

        // assert
        Assert.IsType<CryptoCurrency>(actual);
    }
}