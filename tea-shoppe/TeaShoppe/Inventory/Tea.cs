using TeaShoppe.Domain;

namespace TeaShoppe.Inventory;

// Type "tea" defined as record: two objects are equal if data is equal.
public record Tea
{
    public string Name { get;}
    public decimal Price { get; }
    public int SkuId { get; }
    public StarRating Rating { get; private set; }
    
    public Tea(string name, decimal price, StarRating rating, int skuId)
        {
        this.Name = name;
        this.Price = price;
        this.Rating = rating;
        this.SkuId = skuId;
        }
    
    void UpdateRating(StarRating rating)
    {
        this.Rating = rating;
    }
}