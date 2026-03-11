using JetBrains.Annotations;
using TeaShoppe.Domain;
using TeaShoppe.Inventory;
using TeaShoppe.Orders;
using Xunit;

namespace tea_shoppe.Tests.Orders;

[TestSubject(typeof(Order))]
public class OrderTest
{

    [Fact]
    public void Order_WhenNewOrderCreated_ShouldStoreProperCountsAndTotals()
    {
        // arrange
        int quantity = 2;
        int skuId = 103582;
        StarRating rating = new StarRating(3);
        Tea testTea = new Tea("Test Tea", 14.89m, rating, skuId);
        InventoryItem orderItem = new InventoryItem(testTea);
        OrderItem teaOrdered = new OrderItem(orderItem);
        
        // act 
        Order testOrder = new Order(teaOrdered, quantity);
        
        // assert
        Assert.Equal(1, testOrder.NumberOfLineItems());
        Assert.Equal(2, testOrder.TotalItemCount() );
        Assert.Equal(29.78m, testOrder.OrderTotal());
    }
    
    [Fact]
    public void Order_WhenItemRemovedFromOrder_ShouldUpdateCountsAndTotals()
    {
        // arrange
        int quantity = 2;
        int skuId = 103582;
        StarRating rating = new StarRating(3);
        Tea testTea = new Tea("Test Tea", 14.89m, rating, skuId);
        InventoryItem orderItem = new InventoryItem(testTea);
        OrderItem teaOrdered = new OrderItem(orderItem);
        
        // act 
        Order testOrder = new Order(teaOrdered, quantity);
        testOrder.RemoveItem(teaOrdered, 1);
        
        // assert
        Assert.Equal(1, testOrder.NumberOfLineItems());
        Assert.Equal(1, testOrder.TotalItemCount() );
        Assert.Equal(14.89m, testOrder.OrderTotal());
    }
}