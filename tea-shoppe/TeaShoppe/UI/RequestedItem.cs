using TeaShoppe.Decorators;
using TeaShoppe.Inventory;

namespace TeaShoppe.UI;

public class RequestedItem
{
    public string TeaName { get;}
    public StarRating Rating { get; }
    public decimal Price { get; }
    public int TeaID { get; }
    public bool IsPricePrimary { get; }
    public bool IsRatingPrimary { get; }
    public SortDirection priceDirection { get; }
    public SortDirection ratingDirection { get; }
    public bool InStock { get; }
    

    public RequestedItem(Tea tea, bool isPricePrimary, bool isRatingPrimary, SortDirection priceDirection,
        SortDirection ratingDirection,  bool inStock)
    {
        TeaName = tea.Name;
        Rating = tea.Rating;
        IsPricePrimary = isPricePrimary;
        IsRatingPrimary = isRatingPrimary;
        this.priceDirection = priceDirection;
        this.ratingDirection = ratingDirection;
        InStock = inStock;
    }
}