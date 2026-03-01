using JetBrains.Annotations;
using TeaShoppe.Decorators;
using TeaShoppe.Inventory;
using Xunit;

namespace tea_shoppe.Tests.Decorators;

[TestSubject(typeof(TeaByQuantity))]
public class TeaByQuantityTest
{

    [Fact]
    public void TestTeaByQuantity()
    {
        // arrange
        var catalog = new TeaCatalog();
        IRepository testRepo = new TeaRepository(catalog.Items);
        int qty = 10;
        
        // act 
        testRepo = new TeaByQuantity(testRepo, qty);
        var result = testRepo.GetInventory();
        
        // assert
        Assert.All(result, item => Assert.True(item.Quantity >= qty));
    }
}