using System.IO;
using JetBrains.Annotations;
using TeaShoppe.Inventory;
using TeaShoppe.Payment;
using TeaShoppe.Orders;
using Xunit;

namespace tea_shoppe.Tests.Payment;

[TestSubject(typeof(PaymentProcessor))]
public class PaymentProcessorTest
{

    [Fact]
    public void TestPaymentProcessor1()
    {
        // arrange
        var input = new StringReader("1234567890123456\n");
        var output = new StringWriter();
        IPaymentStrategy testStrategy = new CreditCard(input, output);
        int quantity = 2;
        StarRating rating = new StarRating(3);
        Tea testTea = new Tea("Test Tea", 14.89m, rating);
        RepositoryItem orderItem = new RepositoryItem(testTea, quantity);
        OrderItem teaOrdered = new OrderItem(orderItem, quantity);
        Order testOrder = new Order(teaOrdered);
        
        // act
        PaymentProcessor testProcessor = new PaymentProcessor(testStrategy);
        
        // assert
        Assert.Equal(testStrategy, testProcessor.GetStrategy);

    }
}