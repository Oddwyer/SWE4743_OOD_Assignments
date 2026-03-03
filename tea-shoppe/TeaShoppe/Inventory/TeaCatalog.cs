using TeaShoppe.Domain;

namespace TeaShoppe.Inventory;

public class TeaCatalog
{
    //Keeps default catalog of items immutable. 
    private readonly IReadOnlyList<InventoryItem> _items = new List<InventoryItem>
    {
        new InventoryItem(new Tea("Green Tea", 15.99m, new StarRating(4), 104582),50),
        new InventoryItem(new Tea("Black Tea", 12.49m, new StarRating(5),218947), 75),
        new InventoryItem(new Tea("Herbal Tea", 14.29m, new StarRating(3),336195), 30),
        new InventoryItem(new Tea("Oolong Tea", 18.00m, new StarRating(5), 442873), 10),
        new InventoryItem(new Tea("Matcha", 29.99m, new StarRating(4), 507316), 0),
        new InventoryItem(new Tea("White Tea", 22.50m, new StarRating(4), 618254), 25),
        new InventoryItem(new Tea("Chai Tea", 10.99m, new StarRating(3), 6724901), 60),
        new InventoryItem(new Tea("Earl Grey", 13.99m, new StarRating(5),835462), 45),
        new InventoryItem(new Tea("Rooibos", 17.10m, new StarRating(5), 946173), 0),
        new InventoryItem(new Tea("Mint Tea", 11.89m, new StarRating(1), 159804), 80),
        new InventoryItem(new Tea("Jasmine Green", 16.75m, new StarRating(4), 267531), 35),
        new InventoryItem(new Tea("Darjeeling", 21.60m, new StarRating(5), 378692), 18)
    };
    
    // Shorthand for get method:
    public IReadOnlyList<InventoryItem> Items => _items;
}