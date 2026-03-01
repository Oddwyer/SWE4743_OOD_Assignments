using TeaShoppe.Decorators;
using TeaShoppe.Inventory;

namespace TeaShoppe.UI;

// RequestedItem context object to encapsulate multiple search specifications.
public class RequestedItem
{
    public string ? SearchName { get; set; }
    public int ? MinRating { get; set; }
    public int ? MaxRating { get; set; }
    public int ? Quantity { get; set; }
    public decimal ? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public PrimarySort Sort { get; set; } = PrimarySort.Price;
    public SortDirection PriceDirection { get; set; } =  SortDirection.Ascending;
    public SortDirection RatingDirection { get; set; } =  SortDirection.Ascending;
    public bool ? IsInStock { get; set; } = true;
}