using JetBrains.Annotations;
using TeaShoppe.Decorators;
using TeaShoppe.Inventory;
using Xunit;

namespace TeaShoppe.Tests.Decorators;

[TestSubject(typeof(TeaByRating))]
public class TeaByRatingTest
{

    [Fact]
    public void TeaByRating_WhenMinAndMaxDefined_ShouldReturnItemsBetweenMinAndMax()
    {
        // arrange
        var catalog = new TeaCatalog();
        IInventory testRepo = new TeaInventory(catalog.Items);
        int min = 2;
        int max = 5;
        var tea = new RequestedItem
        {
            MinRating =  min,
            MaxRating = max
        };
        
        // act 
        testRepo = new TeaByRating(testRepo, tea);
        var result = testRepo.GetInventory();
        
        // assert -> range
        Assert.All(result, item => Assert.True(item.RatingValue >= min && item.RatingValue <= max));
        
    }
    
    [Fact]
    public void TeaByRating_WhenMinAndMaxDefined_ShouldIncludeMinAndMaxRatings()
    {
        // arrange
        var catalog = new TeaCatalog();
        IInventory testRepo = new TeaInventory(catalog.Items);
        int min = 1;
        int max = 5;
        var tea = new RequestedItem
        {
            MinRating =  min,
            MaxRating = max
        };
        
        // act 
        testRepo = new TeaByRating(testRepo, tea);
        var result = testRepo.GetInventory();
        
        // assert -> exacts
        Assert.Contains(result, x => x.RatingValue == min);
        Assert.Contains(result, x => x.RatingValue == max);
    }

}