using TeaShoppe.Domain;

namespace TeaShoppe.Inventory;

// Requested item context object to encapsulate multiple search specifications.
public class RequestedItem
{
    public string ? SearchName { get; set; }
    public int MinRating { get; set; } = 3;
    public int MaxRating { get; set; } = 5;
    public int? Quantity { get; set; } = 0;
    public decimal MinPrice { get; set; } = 0.00m;
    public decimal MaxPrice { get; set; } = 1000.00m;
    public PrimarySort Sort { get; set; } = PrimarySort.Price;
    public SortDirection PriceDirection { get; set; } =  SortDirection.Ascending;
    public SortDirection RatingDirection { get; set; } =  SortDirection.Descending;
    public bool? IsInStock { get; set; }
    
}