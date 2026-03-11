using JetBrains.Annotations;
using TeaShoppe.Decorators;
using TeaShoppe.Inventory;
using Xunit;

namespace TeaShoppe.Tests.Decorators;

[TestSubject(typeof(TeaByPrice))]
public class TeaByPriceTest
{

    [Fact]
    public void TeaByPrice_WhenMinAndMaxDefined_ShouldReturnOnlyItemsWithinRange()
    {
        // arrange
        var catalog = new TeaCatalog();
        IInventory testRepo = new TeaInventory(catalog.Items);
        decimal min = 13.99m;
        decimal max = 22.50m;
        var tea = new RequestedItem
        {
            MinPrice = min,
            MaxPrice = max
        };
        
        // act 
        testRepo = new TeaByPrice(testRepo, tea);
        var result = testRepo.GetInventory();
        
        // assert -> range
        Assert.All(result, item => Assert.True(item.RetailPrice >= min && item.RetailPrice <= max));
    }
    
    [Fact]
    public void TeaByPrice_WhenMinAndMaxDefined_ShouldContainMinandMaxPrices()
    {
        // arrange
        var catalog = new TeaCatalog();
        IInventory testRepo = new TeaInventory(catalog.Items);
        decimal min = 13.99m;
        decimal max = 22.50m;
        var tea = new RequestedItem
        {
            MinPrice = min,
            MaxPrice = max
        };

        // act 
        testRepo = new TeaByPrice(testRepo, tea);
        var result = testRepo.GetInventory();
        
        // assert -> exacts
        Assert.Contains(result, x => x.RetailPrice == min);
        Assert.Contains(result, x => x.RetailPrice == max);
    }

}