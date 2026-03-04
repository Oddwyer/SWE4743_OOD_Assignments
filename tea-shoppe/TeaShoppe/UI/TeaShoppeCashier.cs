using TeaShoppe.Domain;
using TeaShoppe.Inventory;
using TeaShoppe.Payment;


namespace TeaShoppe.UI;

public class TeaShoppeCashier
{
    private TeaShoppeFacade shoppe;
    bool stillShopping = true;

    string selectMethod = """
                          *** Choose a payment method: 
                          *** Choose a payment method:
                          1. Credit Card
                          2. Apple Pay
                          3. CryptoCurrency
                          Selection:
                          """;

    // Method to have cashier run shoppe.

    public void RunShoppe()
    {
        var requestedItem = ShoppeOpen();

        // Display search results
        IInventory results = shoppe.PerformQuery(requestedItem);
        var list = results.GetInventory();
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
    }

    // Customer checkout
    public void CheckOut()
    {
        shoppe.DisplayOrder();

        // Request payment type
        Console.Write(selectMethod);
        int method = int.Parse(Console.ReadLine());

        // Accept payment
        AcceptPayment(method);
    }

    // Open Shoppe and take requests.
    public static RequestedItem ShoppeOpen()
    {
        RequestedItem item = new RequestedItem();
        Console.WriteLine("\n========================Welcome to Sweet Teas===============================");
        Console.WriteLine("\nComplete the prompts to search our selection of fine teas.\n");
        
        Console.Write("* Tea name contains (leave blank for all names): ");
        item.SearchName = Console.ReadLine();
       
        Console.Write("* Is available? (Y/N, default Y): ");
        string? available = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(available))
        {
            item.IsInStock = null;
        }
        else if (char.ToUpper(available[0]) == 'N')
        {
            item.IsInStock = false;
        }
        else if (char.ToUpper(available[0]) == 'Y')
        {
            item.IsInStock = false;
        }
        
        Console.Write("* Price minimum (default $0): ");
        string input = Console.ReadLine();
        if (!decimal.TryParse(input, out decimal minValue))
        {
            minValue = 0.00m;
        }

        item.MinPrice = minValue;
        // TODO: null value logic
        Console.Write("*Price maximum (default $1000): ");
        input = Console.ReadLine();
        if (!decimal.TryParse(input, out decimal maxValue))
        {
            maxValue = 1000.00m;
        }

        item.MaxPrice = maxValue;
        Console.Write("* Star rating minimum (1-5, default 1): ");
        item.MinRating = int.Parse(Console.ReadLine());
        Console.Write("* Star rating maximum (1-5, default 5): ");
        item.MaxRating = int.Parse(Console.ReadLine());
        Console.Write("* Minimum quantity (default 1): ");
        item.Quantity = int.Parse(Console.ReadLine());
        Console.Write("\n* Sort Priority (P for Price, R for Rating, default P): ");
        char sortPriority = char.Parse(Console.ReadLine());
        if (char.ToUpper(sortPriority) == 'R')
        {
            item.Sort = PrimarySort.Rating;
        }

        Console.Write("* Sort by Price (A/D, default A): ");
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

        return item;
    }


    // Accept payment.
    public void AcceptPayment(int paymentMethod)
    {
        IPaymentStrategy strategy;
        switch (paymentMethod)
        {
            case 1:
                TextReader input = new StringReader("");
                TextWriter output = new StringWriter();
                strategy = new CreditCard(input, output);
                shoppe.AcceptPayment(strategy);
                break;
            case 2:
                strategy = new ApplePay();
                shoppe.AcceptPayment(strategy);
                break;
            case 3:
                strategy = new CryptoCurrency();
                shoppe.AcceptPayment(strategy);
                break;
            default:
                Console.Write("Please enter a valid choice: ");
                break;
        }
    }
}