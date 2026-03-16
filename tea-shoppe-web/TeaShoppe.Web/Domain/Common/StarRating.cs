namespace TeaShoppe.Web.Domain.Common;

/// <summary>
/// Rating value object to enforce rating invariants.
/// </summary>
public class StarRating
{
    public int Rating { get; }

    public StarRating(int rating)
    {
        if (rating < 1 || rating > 5)
        {
            throw new ArgumentOutOfRangeException(nameof(rating), "This is not a valid rating.");
        }

        Rating = rating;
    }
}