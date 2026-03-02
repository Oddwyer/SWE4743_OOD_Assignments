using JetBrains.Annotations;
using TeaShoppe.Inventory;
using Xunit;

namespace TeaShoppe.Tests.Inventory;

[TestSubject(typeof(InventoryItem))]
public class InventoryItemTest
{

    [Fact]
    public void TestRepositoryItem()
    {
        // arrange
        int quantity = 10;
        StarRating rating = new StarRating(3);
        Tea testTea = new Tea("Test Tea", 14.89m, rating);
        
        // act
        InventoryItem orderItem = new InventoryItem(testTea, quantity);
        
        // assert
        Assert.Equal(testTea.Name, orderItem.Name);
        Assert.Equal(testTea.Price, orderItem.RetailPrice);
        Assert.Equal(quantity, orderItem.Quantity);
        Assert.Equal(rating, orderItem.Rating);
    }
    
    
}