using TeaShoppe.Domain;

namespace TeaShoppe.Inventory;

public class TeaCatalog
{
    //Keeps default catalog of items immutable. 
    private readonly IReadOnlyList<InventoryItem> _items = new List<InventoryItem>
    {
        new InventoryItem(new Tea("Green Tea", 15.99m, new StarRating(4)),50),
        new InventoryItem(new Tea("Black Tea", 12.49m, new StarRating(5)),75),
        new InventoryItem(new Tea("Herbal Tea", 14.29m, new StarRating(3)),30),
        new InventoryItem(new Tea("Oolong Tea", 18.00m, new StarRating(5)), 10),
        new InventoryItem(new Tea("Matcha", 29.99m, new StarRating(4)), 0),
        new InventoryItem(new Tea("White Tea", 22.50m, new StarRating(4)), 25),
        new InventoryItem(new Tea("Chai Tea", 10.99m, new StarRating(3)), 60),
        new InventoryItem(new Tea("Earl Grey", 13.99m, new StarRating(5)), 45),
        new InventoryItem(new Tea("Rooibos", 17.10m, new StarRating(5)), 0),
        new InventoryItem(new Tea("Mint Tea", 11.89m, new StarRating(1)), 80),
        new InventoryItem(new Tea("Jasmine Green", 16.75m, new StarRating(4)), 35),
        new InventoryItem(new Tea("Darjeeling", 21.60m, new StarRating(5)), 18)
    };
    
    // Shorthand for get method:
    public IReadOnlyList<InventoryItem> Items => _items;
}