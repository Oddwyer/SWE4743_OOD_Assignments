using JetBrains.Annotations;
using TeaShoppe.Decorators;
using TeaShoppe.Inventory;
using TeaShoppe.UI;
using Xunit;

namespace TeaShoppe.Tests.Decorators;

[TestSubject(typeof(TeaByAvailability))]
public class TeaByAvailabilityTest
{

    [Fact]
    public void TestTeaByAvailability1()
    {
        // arrange
        var catalog = new TeaCatalog();
        IRepository testRepo = new TeaRepository(catalog.Items);
        var tea = new RequestedItem
        {
            IsInStock = true
        };
        
        // act 
        testRepo = new TeaByAvailability(testRepo, tea);
        var result = testRepo.GetInventory();
        
        // assert
        Assert.All(result, item => Assert.False(item.InStock));
        
    }
    
    [Fact]
    public void TestTeaByAvailability2()
    {
        // arrange
        var catalog = new TeaCatalog();
        IRepository testRepo = new TeaRepository(catalog.Items);
        var tea = new RequestedItem
        {
            IsInStock = true
        };
        
        // act 
        testRepo = new TeaByAvailability(testRepo, tea);
        var result = testRepo.GetInventory();
        
        // assert
        Assert.All(result, item => Assert.True(item.InStock));
        
    }
}