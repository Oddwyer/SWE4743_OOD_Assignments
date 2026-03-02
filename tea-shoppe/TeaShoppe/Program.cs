using TeaShoppe.UI;
using TeaShoppe.Domain;

namespace TeaShoppe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            string selectMethod = """
                                  *** Choose a payment method: 
                                  *** Choose a payment method:
                                  1. Credit Card
                                  2. Apple Pay
                                  3. CryptoCurrency
                                  Selection:
                                  """;
            bool stillShopping = true;
            
            do
            {
                var shoppe = new TeaShoppeFacade();
                RequestedItem item = ShoppeOpen();
                string results = shoppe.DisplayQuery(shoppe.PerformQuery(item));
                Console.WriteLine(results);
                int count = results.Count();
                Console.WriteLine($"Purchase an item? Enter item number 1-{count} or 0 to continue (default):");
                int selectedItem = int.Parse(Console.ReadLine());
                // TODO: Logic for adding item selected from query search to order.
                // TODO: Display and request quantity to add. -> Quantity for "Green Tea" (1-50): 2)
                Console.Write(selectMethod);
                int method = int.Parse(Console.ReadLine());
                shoppe.AcceptPayment(method);
                Console.WriteLine("Search for more tea? (Y/N, default Y): ");
                char selection = char.Parse(Console.ReadLine());
                if (char.ToUpper(selection) == 'N')
                {
                    stillShopping = false;
                }
            } while (stillShopping);
            
        }
        
        // Open Shoppe
        public static RequestedItem ShoppeOpen()
        {
            RequestedItem item = new RequestedItem();
            Console.WriteLine("=========Welcome to Sweet Teas============");

            Console.WriteLine("\nComplete the prompts to search our selection of fine teas.");
            Console.WriteLine("* Tea name contains (leave blank for all names): ");
            item.SearchName = Console.ReadLine();
            Console.WriteLine("* Is available? (Y/N, default Y): ");
            char available = char.Parse(Console.ReadLine());
            if (char.ToUpper(available) == 'N')
            {
                item.IsInStock = false;
            }

            Console.WriteLine("* Price minimum (default $0): ");
            item.MinPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("* Price maximum (default $1000): ");
            item.MaxPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("* Star rating minimum (1-5, default 3): ");
            item.MinRating = int.Parse(Console.ReadLine());
            Console.WriteLine("* Star rating maximum (1-5, default 5): ");
            item.MaxRating = int.Parse(Console.ReadLine());
            Console.WriteLine("* Minimum quantity (default 1): ");
            item.Quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("* Sort by Price (A/D, default A): ");
            char priceSort = char.Parse(Console.ReadLine());
            if (char.ToUpper(priceSort) == 'D')
            {
                item.PriceDirection = SortDirection.Descending;
            }

            Console.WriteLine("* Sort by Star rating (A/D, default D): ");
            char ratingSort = char.Parse(Console.ReadLine());
            if (char.ToUpper(ratingSort) == 'A')
            {
                item.RatingDirection = SortDirection.Ascending;
            }

            Console.WriteLine("* Sort Priority (P for Price, R for Rating, default P): ");
            char sortPriority = char.Parse(Console.ReadLine());
            if (char.ToUpper(sortPriority) == 'R')
            {
                item.Sort = PrimarySort.Rating;
            }

            return item;
        }
        
        
    }
}