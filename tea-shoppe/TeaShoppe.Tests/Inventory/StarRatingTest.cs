using System;
using JetBrains.Annotations;
using TeaShoppe.Domain;
using Xunit;

namespace TeaShoppe.Tests.Inventory;

[TestSubject(typeof(StarRating))]
public class StarRatingTest
{

    [Fact]
    public void StarRating_WhenRatingIsAboveRange_ShouldThrowException()
    {
        // arrange
        int rate1 = 6;
        
        // act + assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new StarRating(rate1));
    }
    
    [Fact]
    public void StarRating_WhenRatingIsBelowRange_ShouldThrowException()
    {
        // arrange
        int rate2 = -1;
        
        // act + assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new StarRating(rate2));
    }
    
    
    [Fact]
    public void StarRating_WhenRatingisCreated_ShouldStorePassedRating()
    {
        // arrange
        int rate3 = 3;
        
        // act 
        StarRating rating3 = new StarRating(rate3);
        
        // assert
        Assert.Equal(rate3, rating3.Rating);
    }

}