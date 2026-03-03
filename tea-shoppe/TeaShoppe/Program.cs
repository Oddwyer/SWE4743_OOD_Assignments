using TeaShoppe.UI;
using TeaShoppe.Domain;
using TeaShoppe.Inventory;

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
            
            // Open shoppe
            var shoppe = new TeaShoppeFacade();
            do
            {
                RequestedItem item = ShoppeOpen();
                
                // Display search results
                IInventory results = shoppe.PerformQuery(item);
                var list =  results.GetInventory();
                string displayResults = shoppe.DisplayQuery(results);
                Console.WriteLine(displayResults);
                
                // Confirm purchase and quantity
                int count = list.Count();
                Console.WriteLine($"Purchase an item? Enter item number 1-{count} or 0 to continue (default):");
                int itemNumber = int.Parse(Console.ReadLine());
                InventoryItem selectedItem = list[itemNumber - 1];
                Console.WriteLine($"Quantity for \"{selectedItem.Name}\" (1-{selectedItem.StockCount}: ");
                int quantity = int.Parse(Console.ReadLine());
                
                // Add to order
                shoppe.AddToOrder(selectedItem, quantity);
                
                // Confirm still shopping
                Console.WriteLine("Search for more tea? (Y/N, default Y): ");
                char selection = char.Parse(Console.ReadLine());
                if (char.ToUpper(selection) == 'N')
                {
                    stillShopping = false;
                }
            } while (stillShopping);
            
            // Display order
            shoppe.DisplayOrder();
            
            // Request payment type
            Console.Write(selectMethod);
            int method = int.Parse(Console.ReadLine());
                
            // Accept payment
            shoppe.AcceptPayment(method);
        }
        
        // Open Shoppe
        public static RequestedItem ShoppeOpen()
        {
            RequestedItem item = new RequestedItem();
            Console.WriteLine("=========Welcome to Sweet Teas============");

            Console.WriteLine("\nComplete the prompts to search our selection of fine teas.");
            Console.Write("* Tea name contains (leave blank for all names): ");
            item.SearchName = Console.ReadLine();
            Console.Write("* Is available? (Y/N, default Y): ");
            char available = char.Parse(Console.ReadLine());
            if (char.ToUpper(available) == 'N')
            {
                item.IsInStock = false;
            }

            Console.Write("* Price minimum (default $0): ");
            string input =  Console.ReadLine();
            if (!decimal.TryParse(input, out decimal minValue))
            {
                minValue = 0.00m;
            }
            item.MinPrice = minValue;
            // TODO: null value logic
            Console.Write("\n*Price maximum (default $1000): ");
            input =  Console.ReadLine();
            if (!decimal.TryParse(input, out decimal maxValue))
            {
                maxValue = 1000.00m;
            }
            item.MaxPrice = maxValue;
            Console.Write("\n* Star rating minimum (1-5, default 3): ");
            item.MinRating = int.Parse(Console.ReadLine());
            Console.Write("\n* Star rating maximum (1-5, default 5): ");
            item.MaxRating = int.Parse(Console.ReadLine());
            Console.Write("\n* Minimum quantity (default 1): ");
            item.Quantity = int.Parse(Console.ReadLine());
            Console.Write("\n* Sort by Price (A/D, default A): ");
            char priceSort = char.Parse(Console.ReadLine());
            if (char.ToUpper(priceSort) == 'D')
            {
                item.PriceDirection = SortDirection.Descending;
            }

            Console.Write("* Sort by Star rating (A/D, default D): ");
            char ratingSort = char.Parse(Console.ReadLine());
            if (char.ToUpper(ratingSort) == 'A')
            {
                item.RatingDirection = SortDirection.Ascending;
            }

            Console.Write("\n* Sort Priority (P for Price, R for Rating, default P): ");
            char sortPriority = char.Parse(Console.ReadLine());
            if (char.ToUpper(sortPriority) == 'R')
            {
                item.Sort = PrimarySort.Rating;
            }

            return item;
        }
        
        
    }
}