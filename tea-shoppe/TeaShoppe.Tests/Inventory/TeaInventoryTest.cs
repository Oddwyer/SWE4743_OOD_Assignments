using JetBrains.Annotations;
using TeaShoppe.Inventory;
using Xunit;

namespace tea_shoppe.Tests.Inventory;

[TestSubject(typeof(TeaInventory))]
public class TeaInventoryTest
{

    [Fact]
    public void TestTeaInventory1()
    {
        // arrange
        TeaCatalog testCatalog = new TeaCatalog();
        int quantity = 10;
        StarRating rating = new StarRating(3);
        Tea testTea = new Tea("Test Tea", 14.89m, rating);
        InventoryItem newItem = new InventoryItem(testTea, quantity);
        
        // act
        TeaInventory testInventory = new TeaInventory(testCatalog.Items);
        int result = testInventory.InventoryCount;
        testInventory.Add(newItem);
        
        // assert
        Assert.Equal(result+1, testInventory.InventoryCount);
    }
    
    [Fact]
    public void TestTeaInventory2()
    {
        // arrange
        TeaCatalog testCatalog = new TeaCatalog();
        int quantity = 10;
        StarRating rating = new StarRating(3);
        Tea testTea = new Tea("Test Tea", 14.89m, rating);
        InventoryItem newItem = new InventoryItem(testTea, quantity);
        
        // act
        TeaInventory testInventory = new TeaInventory(testCatalog.Items);
        testInventory.Add(newItem);
        
        // assert
        Assert.Contains(newItem, testInventory.GetInventory());
    }
 
    [Fact]
    public void TestTeaInventory3()
    {
        // arrange
        TeaCatalog testCatalog = new TeaCatalog();
        int quantity = 10;
        StarRating rating = new StarRating(3);
        Tea testTea = new Tea("Test Tea", 14.89m, rating);
        InventoryItem newItem = new InventoryItem(testTea, quantity);
        
        // act
        TeaInventory testInventory = new TeaInventory(testCatalog.Items);
        testInventory.Add(newItem);
        testInventory.Add(new InventoryItem(testTea, 3));
        var inventoryItem = testInventory.SearchInventory("Test Tea");
        // assert
        Assert.NotNull(inventoryItem);
        Assert.Equal(13, inventoryItem.Quantity);
    }
}