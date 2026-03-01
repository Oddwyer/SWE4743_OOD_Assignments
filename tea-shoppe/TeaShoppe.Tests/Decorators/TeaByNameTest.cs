using JetBrains.Annotations;
using TeaShoppe.Decorators;
using TeaShoppe.Inventory;
using Xunit;

namespace TeaShoppe.Tests.Decorators;

[TestSubject(typeof(TeaByName))]
public class TeaByNameTest
{

    [Fact]
    public void TestTeaByName1()
    {
        // arrange
        string name = "Green Tea";
        var catalog = new TeaCatalog();
        IRepository testRepo = new TeaRepository(catalog.Items);
        
        // act 
        // TODO: Update param to Requested Item
        testRepo = new TeaByName(testRepo, name);
        var result = testRepo.GetInventory();
        
        // assert
        Assert.All(result, item => Assert.Equal("Green Tea", item.Name));

    }
    
    [Fact]
    public void TestTeaByName2()
    {
        // arrange
        string name = "green tea";
        var catalog = new TeaCatalog();
        IRepository testRepo = new TeaRepository(catalog.Items);
        
        // act 
        testRepo = new TeaByName(testRepo, name);
        var result = testRepo.GetInventory();
        
        // assert
        Assert.All(result, item => Assert.Equal(name, item.Name, ignoreCase: true));
    }
}