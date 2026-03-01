using JetBrains.Annotations;
using TeaShoppe.Inventory;
using Xunit;

namespace TeaShoppe.Tests.Inventory;

[TestSubject(typeof(StarRating))]
public class StarRatingTest
{

    [Fact]
    public void TestStarRating1()
    {
        // arrange
        int rate1 = 6;
        
        // act 
        StarRating rating1 = new StarRating(rate1);
        
        // assert
        Assert.Equal(rate1, rating1.Rating);
    }
    
    [Fact]
    public void TestStarRating2()
    {
        // arrange
        int rate2 = -1;
        
        // act 
        StarRating rating2 = new StarRating(rate2);
        
        // assert
        Assert.Equal(rate2, rating2.Rating);
    }
    
    
    [Fact]
    public void TestStarRating3()
    {
        // arrange
        int rate3 = 3;
        
        // act 
        StarRating rating3 = new StarRating(rate3);
        
        // assert
        Assert.Equal(rate3, rating3.Rating);
    }

}