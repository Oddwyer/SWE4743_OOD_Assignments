using System.IO;
using JetBrains.Annotations;
using TeaShoppe.Payment;
using Xunit;

namespace tea_shoppe.Tests.Payment;

[TestSubject(typeof(CreditCard))]
public class CreditCardTest
{

    [Fact]
    public void TestCreditCard1()
    {
        // arrange
        var input = new StringReader("1234567890123456\n");
        var output = new StringWriter();

        // act
        IPaymentStrategy paymentStrategy = new CreditCard(input, output);
        bool result = paymentStrategy.Pay(14.98m);
        
        // assert
        Assert.True(result);

    }
    
    [Fact]
    public void TestCreditCard2()
    {
        // arrange
        var input = new StringReader("1234-5678-9012-3456\n");
        var output = new StringWriter();

        // act
        IPaymentStrategy paymentStrategy = new CreditCard(input, output);
        bool result = paymentStrategy.Pay(14.98m);
        
        // assert
        Assert.True(result);

    }
    
    [Fact]
    public void TestCreditCard3()
    {
        // arrange
        var input = new StringReader("1234 5678 9012 3456\n");
        var output = new StringWriter();

        // act
        IPaymentStrategy paymentStrategy = new CreditCard(input, output);
        bool result = paymentStrategy.Pay(14.98m);
        
        // assert
        Assert.True(result);

    }
    
    [Fact]
    public void TestCreditCard4()
    {
        // arrange
        var input = new StringReader("123A-5678-9012-3456\n");
        var output = new StringWriter();

        // act
        IPaymentStrategy paymentStrategy = new CreditCard(input, output);
        bool result = paymentStrategy.Pay(14.98m);
        
        // assert
        Assert.False(result);

    }
}
