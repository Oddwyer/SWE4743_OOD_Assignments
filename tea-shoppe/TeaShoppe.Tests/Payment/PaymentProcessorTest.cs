using System.IO;
using JetBrains.Annotations;
using TeaShoppe.Inventory;
using TeaShoppe.Payment;
using TeaShoppe.Orders;
using TeaShoppe.Domain;
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
        IPaymentStrategy creditCard = new CreditCard(input, output);
        int quantity = 2;
        int skuId = 103582;
        StarRating rating = new StarRating(3);
        Tea testTea = new Tea("Test Tea", 14.89m, rating, skuId);
        InventoryItem orderItem = new InventoryItem(testTea, quantity);
        OrderItem teaOrdered = new OrderItem(orderItem);
        Order testOrder = new Order(teaOrdered, quantity);
        
        // act
        PaymentProcessor testProcessor = new PaymentProcessor(creditCard, input, output);
        
        // assert
        Assert.Equal(creditCard, testProcessor.GetStrategy);

    }
    
    [Fact]
    public void TestPaymentProcessor2()
    {
        // arrange
        var input = new StringReader("1234567890123456\n");
        var output = new StringWriter();
        IPaymentStrategy creditCard = new CreditCard(input, output);
        int quantity = 2;
        int skuId = 103582;
        StarRating rating = new StarRating(3);
        Tea testTea = new Tea("Test Tea", 14.89m, rating, skuId);
        InventoryItem orderItem = new InventoryItem(testTea, quantity);
        OrderItem teaOrdered = new OrderItem(orderItem);
        Order testOrder = new Order(teaOrdered, quantity);
        
        // act
        PaymentProcessor testProcessor = new PaymentProcessor(creditCard, input, output);
        IPaymentStrategy apple = new ApplePay(input, output);
        testProcessor.SetStrategy(apple);
        
        // assert
        Assert.Equal(apple, testProcessor.GetStrategy);

    }
}