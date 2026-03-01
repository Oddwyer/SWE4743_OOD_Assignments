using JetBrains.Annotations;
using TeaShoppe.Decorators;
using TeaShoppe.Inventory;
using Xunit;

namespace TeaShoppe.Tests.Decorators;

[TestSubject(typeof(TeaByRating))]
public class TeaByRatingTest
{

    [Fact]
    public void TestByRating1()
    {
        // arrange
        var catalog = new TeaCatalog();
        IRepository testRepo = new TeaRepository(catalog.Items);
        int min = 2;
        int max = 5;
        
        // act 
        // TODO: Update param to Requested Item
        testRepo = new TeaByRating(testRepo, min, max);
        var result = testRepo.GetInventory();
        
        // assert -> range
        Assert.All(result, item => Assert.True(item.RatingValue >= min && item.RatingValue <= max));
        
    }
    
    [Fact]
    public void TestByRating2()
    {
        // arrange
        var catalog = new TeaCatalog();
        IRepository testRepo = new TeaRepository(catalog.Items);
        int min = 1;
        int max = 5;
        
        // act 
        testRepo = new TeaByRating(testRepo, min, max);
        var result = testRepo.GetInventory();
        
        // assert -> exacts
        Assert.Contains(result, x => x.RatingValue == min);
        Assert.Contains(result, x => x.RatingValue == max);
    }

}