using JetBrains.Annotations;
using TeaShoppe.Decorators;
using TeaShoppe.Inventory;
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
        bool inStock = true;
        
        // act 
        // TODO: Update param to RequestedItem
        testRepo = new TeaByAvailability(testRepo, inStock);
        var result = testRepo.GetInventory();
        
        // assert
        Assert.All(result, item => Assert.Equal(false, item.InStock));
        
    }
    
    [Fact]
    public void TestTeaByAvailability2()
    {
        // arrange
        var catalog = new TeaCatalog();
        IRepository testRepo = new TeaRepository(catalog.Items);
        bool inStock = true;
        
        // act 
        testRepo = new TeaByAvailability(testRepo, inStock);
        var result = testRepo.GetInventory();
        
        // assert
        Assert.All(result, item => Assert.Equal(true, item.InStock));
        
    }
}