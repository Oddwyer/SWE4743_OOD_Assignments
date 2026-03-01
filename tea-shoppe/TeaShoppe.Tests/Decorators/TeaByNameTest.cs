using JetBrains.Annotations;
using TeaShoppe.Decorators;
using TeaShoppe.Inventory;
using Xunit;

namespace TeaShoppe.Tests.Decorators;

[TestSubject(typeof(TeaByName))]
public class TeaByNameTest
{

    [Fact]
    public void TestTeaByName()
    {
        // arrange
        string name = "Green Tea";
        var catalog = new TeaCatalog();
        IRepository testRepo = new TeaRepository(catalog.Items);
        
        // act 
        testRepo = new TeaByName(testRepo, name);
        var result = testRepo.GetInventory();
        
        // assert
        Assert.All(result, item => Assert.Equal("Green Tea", item.Name));

    }
}