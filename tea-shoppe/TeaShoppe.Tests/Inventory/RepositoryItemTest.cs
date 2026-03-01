using JetBrains.Annotations;
using TeaShoppe.Inventory;
using Xunit;

namespace tea_shoppe.Tests.Inventory;

[TestSubject(typeof(RepositoryItem))]
public class RepositoryItemTest
{

    [Fact]
    public void TestRepositoryItem()
    {
        // arrange
        string name = "Test Tea";
        decimal price = 14.89m;
        int quantity = 10;
        StarRating rating = new StarRating(3);
        
        // act
        RepositoryItem repositoryItem = new RepositoryItem(name, price, quantity, rating);
        
        // assert
        Assert.Equal(name, repositoryItem.Name);
        Assert.Equal(price, repositoryItem.Price);
        Assert.Equal(quantity, repositoryItem.Quantity);
        Assert.Equal(rating, repositoryItem.Rating);
    }
    
    
}