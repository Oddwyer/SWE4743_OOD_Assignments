using System.ComponentModel;
using TeaShoppe.Domain;
using TeaShoppe.Inventory;
using TeaShoppe.Payment;


namespace TeaShoppe.UI;

public class TeaShoppeCashier
{
    private readonly TeaShoppeFacade _shoppe;
    bool stillShopping = true;

    string selectMethod = """
                          *** Choose a payment method: 
                          *** Choose a payment method:
                          1. Credit Card
                          2. Apple Pay
                          3. CryptoCurrency
                          Selection:
                          """;

    public TeaShoppeCashier(TeaShoppeFacade shoppe)
    {
        _shoppe = shoppe;
    }

    // Method to have cashier run shoppe.

    public void RunShoppe()
    {
        var requestedItem = ShoppeOpen();

        // Display search results
        IInventory results = _shoppe.PerformQuery(requestedItem);
        var list = results.GetInventory();
        string displayResults = _shoppe.DisplayQuery(results);
        Console.WriteLine(displayResults);

        // Confirm purchase and quantity
        int count = list.Count();
        Console.Write($"Purchase an item? Enter item number 1-{count} or 0 to continue (default):");
        int itemNumber = int.Parse(Console.ReadLine());
        InventoryItem selectedItem = list[itemNumber - 1];
        while (selectedItem.StockCount == 0)
        {
            Console.Write(
                "\nItem is currently out of stock. Is there another you'd like to purchase? Enter item number: ");
            itemNumber = int.Parse(Console.ReadLine());
            selectedItem = list[itemNumber - 1];
        }

        Console.Write($"Quantity for \"{selectedItem.Name}\" (1-{selectedItem.StockCount}): ");
        int quantity = int.Parse(Console.ReadLine());

        // Add to order
        bool added = _shoppe.AddToOrder(selectedItem, quantity);
        if (added)
        {
            Console.WriteLine("Item added to order.");
        }
        else
        {
            Console.WriteLine("We were unable to add the item to your order.");
        }
    }

    // Customer checkout
    public void CheckOut()
    {
        _shoppe.DisplayOrder();

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
        string input;
        Console.WriteLine("\n========================Welcome to Sweet Teas===============================");
        Console.WriteLine("\nComplete the prompts to search our selection of fine teas.\n");

        Console.Write("* Tea name contains (leave blank for all names): ");
        item.SearchName = Console.ReadLine();

        Console.Write("* Is available? (Y/N, default all): ");
        string? entry = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(entry))
        {
            item.IsInStock = null;
        }
        else if (char.ToUpper(entry[0]) == 'N')
        {
            item.IsInStock = false;
        }
        else if (char.ToUpper(entry[0]) == 'Y')
        {
            item.IsInStock = true;
        }

        Console.Write("* Price minimum (default $0): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (decimal.TryParse(input, out decimal price))
            {
                item.MinPrice = decimal.Parse(input);
            }
        }

        Console.Write("* Price maximum (default $1000): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (decimal.TryParse(input, out decimal price))
            {
                item.MaxPrice = decimal.Parse(input);
            }
        }

        Console.Write("* Star rating minimum (1-5, default 1): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (int.TryParse(input, out int starRating))
            {
                item.MinRating = starRating;
            }
        }

        Console.Write("* Star rating maximum (1-5, default 5): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (int.TryParse(input, out int starRating))
                item.MaxRating = starRating;
        }

        Console.Write("* Minimum quantity (default 1): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (int.TryParse(input, out int quantity))
            {
                item.Quantity = quantity;
            }
        }

        Console.Write("* Sort Priority (P for Price, R for Rating, default P): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (char.ToUpper(input[0]) == 'R')
            {
                item.Sort = PrimarySort.Rating;
            }
        }

        Console.Write("* Sort by Price (A/D, default A): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (char.ToUpper(input[0]) == 'D')
            {
                item.PriceDirection = SortDirection.Descending;
            }
        }

        Console.Write("* Sort by Star rating (A/D, default D): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (char.ToUpper(input[0]) == 'A')
            {
                item.RatingDirection = SortDirection.Ascending;
            }
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
                _shoppe.AcceptPayment(strategy);
                break;
            case 2:
                strategy = new ApplePay();
                _shoppe.AcceptPayment(strategy);
                break;
            case 3:
                strategy = new CryptoCurrency();
                _shoppe.AcceptPayment(strategy);
                break;
            default:
                Console.Write("Please enter a valid choice: ");
                break;
        }
    }
}