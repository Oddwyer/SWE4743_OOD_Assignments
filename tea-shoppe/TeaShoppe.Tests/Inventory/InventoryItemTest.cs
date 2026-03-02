using JetBrains.Annotations;
using TeaShoppe.Inventory;
using TeaShoppe.Domain;
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
        InventoryItem newItem = new InventoryItem(testTea, quantity);
        
        // assert
        Assert.Equal(testTea.Name, newItem.Name);
        Assert.Equal(testTea.Price, newItem.RetailPrice);
        Assert.Equal(quantity, newItem.Quantity);
        Assert.Equal(rating, newItem.Rating);
    }
    
    
}