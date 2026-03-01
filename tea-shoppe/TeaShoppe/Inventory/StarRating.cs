namespace TeaShoppe.Inventory;

// Rating class to prevent rating invariants.
public class StarRating
{
    public int Rating {get;}
    
    public StarRating(int rating)
    {
            if (rating < 1 || rating > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "This is not a valid rating.");
            }
            else
            {
                Rating = rating;
            }
        
    }
}