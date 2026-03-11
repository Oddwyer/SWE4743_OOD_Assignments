using JetBrains.Annotations;
using TeaShoppe.Inventory;
using TeaShoppe.Domain;
using Xunit;

namespace tea_shoppe.Tests.Inventory;

[TestSubject(typeof(TeaInventory))]
public class TeaInventoryTest
{

    [Fact]
    public void TeaInventory_WhenNewItemAddedToInventory_ShouldIncrementInventoryCount()
    {
        // arrange
        TeaCatalog testCatalog = new TeaCatalog();
        int quantity = 10;
        int skuId = 103582;
        StarRating rating = new StarRating(3);
        Tea testTea = new Tea("Test Tea", 14.89m, rating, skuId);
        InventoryItem newItem = new InventoryItem(testTea);
        
        // act
        TeaInventory testInventory = new TeaInventory(testCatalog.Items);
        int result = testInventory.InventoryCount;
        testInventory.Add(newItem, quantity);
        
        // assert
        Assert.Equal(result+1, testInventory.InventoryCount);
    }
    
    [Fact]
    public void TeaInventory_WhenNewItemAddedToInventory_ShouldStoreItemInInventory()
    {
        // arrange
        TeaCatalog testCatalog = new TeaCatalog();
        int quantity = 10;
        int skuId = 103582;
        StarRating rating = new StarRating(3);
        Tea testTea = new Tea("Test Tea", 14.89m, rating, skuId);
        InventoryItem newItem = new InventoryItem(testTea, quantity);
        
        // act
        TeaInventory testInventory = new TeaInventory(testCatalog.Items);
        testInventory.Add(newItem, quantity);
        
        // assert
        Assert.Contains(newItem, testInventory.GetInventory());
    }
 
    [Fact]
    public void TeaInventory_WhenNewItemAndQuantityAddedToInventory_ShouldUpdateStockCount()
    {
        // arrange
        TeaCatalog testCatalog = new TeaCatalog();
        int quantity = 10;
        int skuId = 103582;
        StarRating rating = new StarRating(3);
        Tea testTea = new Tea("Test Tea", 14.89m, rating, skuId);
        InventoryItem newItem = new InventoryItem(testTea, quantity);
        TeaInventory testInventory = new TeaInventory(testCatalog.Items);
        
        // act
        testInventory.Add(newItem, quantity);
        testInventory.Add(newItem, 3);
        var inventoryItem = testInventory.SearchInventory(newItem.SkuId);
        
        // assert
        Assert.NotNull(inventoryItem);
        Assert.Equal(13, testInventory.InventoryCount);
    }
}