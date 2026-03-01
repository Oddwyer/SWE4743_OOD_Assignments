namespace TeaShoppe.Inventory;

public class TeaCatalog
{
    //Keeps default catalog of items immutable. 
    private readonly IReadOnlyList<RepositoryItem> _items = new List<RepositoryItem>
    {
        new RepositoryItem("Green Tea", 15.99m, 50, new StarRating(4)),
        new RepositoryItem("Black Tea", 12.49m, 75, new StarRating(5)),
        new RepositoryItem("Herbal Tea", 14.29m, 30, new StarRating(3)),
        new RepositoryItem("Oolong Tea", 18.00m, 10, new StarRating(5)),
        new RepositoryItem("Matcha", 29.99m, 0, new StarRating(4)),
        new RepositoryItem("White Tea", 22.50m, 25, new StarRating(4)),
        new RepositoryItem("Chai Tea", 10.99m, 60, new StarRating(3)),
        new RepositoryItem("Earl Grey", 13.99m, 45, new StarRating(5)),
        new RepositoryItem("Rooibos", 17.10m, 0, new StarRating(5)),
        new RepositoryItem("Mint Tea", 11.89m, 80, new StarRating(1)),
        new RepositoryItem("Jasmine Green", 16.75m, 35, new StarRating(4)),
        new RepositoryItem("Darjeeling", 21.60m, 18, new StarRating(5))
    };
    
    // Shorthand for get method:
    public IReadOnlyList<RepositoryItem> Items => _items;
}