namespace TeaShoppe.Inventory;

public class TeaCatalog
{
    //Keeps default catalog of items immutable. 
    private readonly IReadOnlyList<RepositoryItem> _items = new List<RepositoryItem>
    {
        new RepositoryItem(new Tea("Green Tea", 15.99m, new StarRating(4)),50),
        new RepositoryItem(new Tea("Black Tea", 12.49m, new StarRating(5)),75),
        new RepositoryItem(new Tea("Herbal Tea", 14.29m, new StarRating(3)),30),
        new RepositoryItem(new Tea("Oolong Tea", 18.00m, new StarRating(5)), 10),
        new RepositoryItem(new Tea("Matcha", 29.99m, new StarRating(4)), 0),
        new RepositoryItem(new Tea("White Tea", 22.50m, new StarRating(4)), 25),
        new RepositoryItem(new Tea("Chai Tea", 10.99m, new StarRating(3)), 60),
        new RepositoryItem(new Tea("Earl Grey", 13.99m, new StarRating(5)), 45),
        new RepositoryItem(new Tea("Rooibos", 17.10m, new StarRating(5)), 0),
        new RepositoryItem(new Tea("Mint Tea", 11.89m, new StarRating(1)), 80),
        new RepositoryItem(new Tea("Jasmine Green", 16.75m, new StarRating(4)), 35),
        new RepositoryItem(new Tea("Darjeeling", 21.60m, new StarRating(5)), 18)
    };
    
    // Shorthand for get method:
    public IReadOnlyList<RepositoryItem> Items => _items;
}