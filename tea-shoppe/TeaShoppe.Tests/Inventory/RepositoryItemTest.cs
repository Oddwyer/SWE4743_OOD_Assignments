using JetBrains.Annotations;
using TeaShoppe.Inventory;
using Xunit;

namespace TeaShoppe.Tests.Inventory;

[TestSubject(typeof(RepositoryItem))]
public class RepositoryItemTest
{

    [Fact]
    public void TestRepositoryItem()
    {
        // arrange
        int quantity = 10;
        StarRating rating = new StarRating(3);
        Tea testTea = new Tea("Test Tea", 14.89m, rating);
        
        // act
        RepositoryItem repositoryItem = new RepositoryItem(testTea, quantity);
        
        // assert
        Assert.Equal(testTea.Name, repositoryItem.Name);
        Assert.Equal(testTea.Price, repositoryItem.RetailPrice);
        Assert.Equal(quantity, repositoryItem.Quantity);
        Assert.Equal(rating, repositoryItem.Rating);
    }
    
    
}