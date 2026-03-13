namespace TeaShoppe.Web.Domain.Common;

/// <summary>
/// Rating class to prevent rating invariants.
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