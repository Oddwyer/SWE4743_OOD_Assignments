namespace TeaShoppe.Inventory;

public record Tea
{
    public string Name { get;}
    public decimal Price { get; }
    public StarRating Rating { get; private set; }
    
    public Tea(string name, decimal price, StarRating rating)
        {
        this.Name = name;
        this.Price = price;
        this.Rating = rating;
        }
    
    void UpdateRating(StarRating rating)
    {
        this.Rating = rating;
    }
}