using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using TeaShoppe.Domain;
using TeaShoppe.Inventory;
using TeaShoppe.UI;
using Xunit;

namespace tea_shoppe.Tests.UI;

[TestSubject(typeof(TeaShoppeFacade))]
public class TeaShoppeFacadeTest
{

    [Fact]
    public void PerformQuery_WhenQueryByName_ShouldReturnItemsContainingSearchName()
    {
        // arrange
        TextReader reader = new StreamReader("TeaShoppeFacadeTest.txt");
        TextWriter writer = new StreamWriter("TeaShoppeFacadeTest2.txt");
        TeaShoppeFacade testShoppe = new TeaShoppeFacade(reader,  writer);
        RequestedItem testItem =  new RequestedItem();
        testItem.SearchName = "Green Tea";
        
        // act
        IInventory testResults =  testShoppe.PerformQuery(testItem);
        
        // assert
        Assert.Contains(testResults.GetInventory(),
            item => item.Name == "Green Tea");
    }
    
    [Fact]
    public void PerformQuery_WhenQueryByRating_ShouldReturnItemsBetweenMinAndMaxSearchRatings()
    {
        // arrange
        TextReader reader = new StreamReader("TeaShoppeFacadeTest.txt");
        TextWriter writer = new StreamWriter("TeaShoppeFacadeTest2.txt");
        TeaShoppeFacade testShoppe = new TeaShoppeFacade(reader,  writer);
        RequestedItem testItem =  new RequestedItem();
        testItem.MinRating = 1;
        testItem.MaxRating = 4;
        
        // act
        IInventory testResults =  testShoppe.PerformQuery(testItem);
        
        // assert
        Assert.All(testResults.GetInventory(),
            item => Assert.InRange(item.RatingValue, 1, 4));
    }
    
    [Fact]
    public void PerformQuery_WhenQueryByQuantity_ShouldReturnItemsGreaterOrEqualToSearchQuantity()
    {
        // arrange
        TextReader reader = new StreamReader("TeaShoppeFacadeTest.txt");
        TextWriter writer = new StreamWriter("TeaShoppeFacadeTest2.txt");
        TeaShoppeFacade testShoppe = new TeaShoppeFacade(reader,  writer);
        RequestedItem testItem =  new RequestedItem();
        testItem.Quantity = 6;
        testItem.MinRating = 1;
        IInventory testResults =  testShoppe.PerformQuery(testItem);
        
        // assert
        Assert.Equal(10, testResults.GetInventory().Count);
    }
    
    [Fact]
    public void PerformQuery_WhenQueryByMaxPrice_ShouldReturnItemsLessOrEqualToSearchPrice()
    {
        // arrange
        TextReader reader = new StreamReader("TeaShoppeFacadeTest.txt");
        TextWriter writer = new StreamWriter("TeaShoppeFacadeTest2.txt");
        TeaShoppeFacade testShoppe = new TeaShoppeFacade(reader,  writer);
        RequestedItem testItem =  new RequestedItem();
        testItem.MaxPrice = 17.00m;
        testItem.MinRating = 1;
        // act
        IInventory testResults =  testShoppe.PerformQuery(testItem);
        
        // assert
        Assert.Equal(7, testResults.GetInventory().Count);
    }
    
    [Fact]
    public void PerformQuery_WhenQueryByMinPrice_ShouldReturnItemsGreaterOrEqualToSearchPrice()
    {
        // arrange
        TextReader reader = new StreamReader("TeaShoppeFacadeTest.txt");
        TextWriter writer = new StreamWriter("TeaShoppeFacadeTest2.txt");
        TeaShoppeFacade testShoppe = new TeaShoppeFacade(reader,  writer);
        RequestedItem testItem =  new RequestedItem();
        testItem.MinPrice = 15.00m;
        
        // act
        IInventory testResults =  testShoppe.PerformQuery(testItem);
        
        // assert
        Assert.Equal(7, testResults.GetInventory().Count);
    }
    
    [Fact]
    public void PerformQuery_WhenQueryByMinMaxPrice_ShouldReturnItemsBetweenMixAndMaxSearchPrices()
    {
        // arrange
        TextReader reader = new StreamReader("TeaShoppeFacadeTest.txt");
        TextWriter writer = new StreamWriter("TeaShoppeFacadeTest2.txt");
        TeaShoppeFacade testShoppe = new TeaShoppeFacade(reader,  writer);
        RequestedItem testItem =  new RequestedItem();
        testItem.MinPrice = 1.00m;
        testItem.MaxPrice = 30.00m;
        testItem.MinRating = 1;
        
        // act
        IInventory testResults =  testShoppe.PerformQuery(testItem);
        
        // assert
        Assert.Equal(12, testResults.GetInventory().Count);
    }
    
    [Fact]
    public void PerformQuery_WhenQueryIsInStockTrue_ShouldReturnInStockItems()
    {
        // arrange
        TextReader reader = new StreamReader("TeaShoppeFacadeTest.txt");
        TextWriter writer = new StreamWriter("TeaShoppeFacadeTest2.txt");
        TeaShoppeFacade testShoppe = new TeaShoppeFacade(reader,  writer);
        RequestedItem testItem =  new RequestedItem();
        testItem.IsInStock =  true;
        testItem.MinRating = 1;
        
        // act
        IInventory testResults =  testShoppe.PerformQuery(testItem);
        
        // assert
        Assert.Equal(10, testResults.GetInventory().Count);
    }
    
    [Fact]
    public void PerformQuery_WhenQueryIsInStockFalse_ShouldReturnOutOfStockItems()
    {
        // arrange
        TextReader reader = new StreamReader("TeaShoppeFacadeTest.txt");
        TextWriter writer = new StreamWriter("TeaShoppeFacadeTest2.txt");
        TeaShoppeFacade testShoppe = new TeaShoppeFacade(reader,  writer);
        RequestedItem testItem =  new RequestedItem();
        testItem.IsInStock =  false;
        
        // act
        IInventory testResults =  testShoppe.PerformQuery(testItem);
        
        // assert
        Assert.Equal(2, testResults.GetInventory().Count);
    }
    
    [Fact]
    public void PerformQuery_WhenQueryPriceSortAscending_ShouldReturnItemsByAscendingPrice()
    {
        // arrange
        TextReader reader = new StreamReader("TeaShoppeFacadeTest.txt");
        TextWriter writer = new StreamWriter("TeaShoppeFacadeTest2.txt");
        TeaShoppeFacade testShoppe = new TeaShoppeFacade(reader,  writer);
        RequestedItem testItem =  new RequestedItem();
        testItem.Sort = PrimarySort.Price;
        
        // act
        IInventory testResults =  testShoppe.PerformQuery(testItem);
        var results  = testResults.GetInventory().ToList();
        var sorted = results.OrderBy(x => x.RetailPrice);
        
        // assert
        Assert.Equal(results, sorted);
    }
    
    [Fact]
    public void PerformQuery_WhenQueryPriceSortDescending_ShouldReturnItemsByDescendingPrice()
    {
        // arrange
        TextReader reader = new StreamReader("TeaShoppeFacadeTest.txt");
        TextWriter writer = new StreamWriter("TeaShoppeFacadeTest2.txt");
        TeaShoppeFacade testShoppe = new TeaShoppeFacade(reader,  writer);
        RequestedItem testItem =  new RequestedItem();
        testItem.Sort = PrimarySort.Price;
        testItem.PriceDirection = SortDirection.Descending;
        
        // act
        IInventory testResults =  testShoppe.PerformQuery(testItem);
        var results  = testResults.GetInventory().ToList();
        var sorted = results.OrderByDescending(x => x.RetailPrice);
        
        // assert
        Assert.Equal(results, sorted);
    }
    
    [Fact]
    public void PerformQuery_WhenQueryRatingSortAscending_ShouldReturnItemsByAscendingRating()
    {
        // arrange
        TextReader reader = new StreamReader("TeaShoppeFacadeTest.txt");
        TextWriter writer = new StreamWriter("TeaShoppeFacadeTest2.txt");
        TeaShoppeFacade testShoppe = new TeaShoppeFacade(reader,  writer);
        RequestedItem testItem =  new RequestedItem();
        testItem.Sort = PrimarySort.Rating;
        testItem.RatingDirection = SortDirection.Ascending;
        
        // act
        IInventory testResults =  testShoppe.PerformQuery(testItem);
        var results  = testResults.GetInventory().ToList();
        var sorted = results.OrderBy(x => x.RatingValue);
        
        // assert
        Assert.Equal(results, sorted);
    }
    
    [Fact]
    public void PerformQuery_WhenQueryRatingPriceThenRatingSort_ShouldReturnItemsByPriceThenRating()
    {
        // arrange
        TextReader reader = new StreamReader("TeaShoppeFacadeTest.txt");
        TextWriter writer = new StreamWriter("TeaShoppeFacadeTest2.txt");
        TeaShoppeFacade testShoppe = new TeaShoppeFacade(reader,  writer);
        RequestedItem testItem =  new RequestedItem();
        testItem.Sort = PrimarySort.Price;
        testItem.RatingDirection = SortDirection.Ascending;
        testItem.PriceDirection = SortDirection.Ascending;
        
        // act
        IInventory testResults =  testShoppe.PerformQuery(testItem);
        var results  = testResults.GetInventory();
        
        // comparing list<int> here via SKU since two items may have same price and rating.
        var actual = results.Select(x => x.SkuId).ToList();
        var sorted = results.OrderBy(x => x.RetailPrice)
            .ThenBy(x => x.RatingValue)
            .Select(x => x.SkuId).ToList();
        
        // assert
        Assert.Equal(actual, sorted);
    }
    
    [Fact]
    public void PerformQuery_WhenQueryByRatingThenPriceSort_ShouldReturnItemsByRatingThenPrice()
    {
        // arrange
        TextReader reader = new StreamReader("TeaShoppeFacadeTest.txt");
        TextWriter writer = new StreamWriter("TeaShoppeFacadeTest2.txt");
        TeaShoppeFacade testShoppe = new TeaShoppeFacade(reader,  writer);
        RequestedItem testItem =  new RequestedItem();
        testItem.Sort = PrimarySort.Rating;
        testItem.RatingDirection = SortDirection.Ascending;
        testItem.PriceDirection = SortDirection.Ascending;
        
        // act
        IInventory testResults =  testShoppe.PerformQuery(testItem);
        var results  = testResults.GetInventory();
        
        // comparing list<int> here via SKU since two items may have same price and rating.
        var actual = results.Select(x => x.SkuId).ToList();
        var sorted = results.OrderBy(x => x.RatingValue)
            .ThenBy(x => x.RetailPrice)
            .Select(x => x.SkuId).ToList();
        
        // assert
        Assert.Equal(actual, sorted);
    }
}

