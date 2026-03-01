using System.Collections.Generic;
using JetBrains.Annotations;
using TeaShoppe.Decorators;
using TeaShoppe.Inventory;
using TeaShoppe.Orders;
using TeaShoppe.UI;
using Xunit;

namespace tea_shoppe.Tests.Orders;

[TestSubject(typeof(Order))]
public class OrderTest
{

    [Fact]
    public void TestOrder1()
    {
        // arrange
        int quantity = 2;
        StarRating rating = new StarRating(3);
        Tea testTea = new Tea("Test Tea", 14.89m, rating);
        RepositoryItem orderItem = new RepositoryItem(testTea, quantity);
        OrderItem teaOrdered = new OrderItem(orderItem, quantity);
        
        // act 
        Order testOrder = new Order(teaOrdered);
        
        // assert
        Assert.Equal(1, testOrder.NumberOfLineItems());
        Assert.Equal(2, testOrder.TotalItemCount() );
        Assert.True(testOrder.SearchOrder(teaOrdered.ItemId));
        Assert.Equal(29.78m, testOrder.OrderTotal());
        
    }
    
    [Fact]
    public void TestOrder2()
    {
        // arrange
        int quantity = 2;
        StarRating rating = new StarRating(3);
        Tea testTea = new Tea("Test Tea", 14.89m, rating);
        RepositoryItem orderItem = new RepositoryItem(testTea, quantity);
        OrderItem teaOrdered = new OrderItem(orderItem, quantity);
        
        // act 
        Order testOrder = new Order(teaOrdered);
        testOrder.RemoveItem(teaOrdered);
        
        // assert
        Assert.Equal(1, testOrder.NumberOfLineItems());
        Assert.Equal(1, testOrder.TotalItemCount() );
        Assert.True(testOrder.SearchOrder(teaOrdered.ItemId));
        Assert.Equal(14.89m, testOrder.OrderTotal());
        
    }
}