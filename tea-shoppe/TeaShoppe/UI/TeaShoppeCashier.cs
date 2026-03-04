using System.ComponentModel;
using TeaShoppe.Domain;
using TeaShoppe.Inventory;
using TeaShoppe.Payment;

namespace TeaShoppe.UI;

/// <summary>
/// Cashier class to extract user prompts from composition root.
/// </summary>
public class TeaShoppeCashier
{
    private readonly TeaShoppeFacade _shoppe;
    private readonly TextReader _input;
    private readonly TextWriter _output;
    bool stillShopping = true;

    string selectMethod = """
                          *** Choose a payment method: 
                          1. Credit Card
                          2. Apple Pay
                          3. CryptoCurrency
                          Selection: 
                          """;

    public TeaShoppeCashier(TeaShoppeFacade shoppe, TextReader input, TextWriter output)
    {
        _shoppe = shoppe;
        _input = input;
        _output = output;
    }

    // Cashier run shoppe.

    public void RunShoppe()
    {
        var requestedItem = ShoppeOpen();

        // Display search results
        IInventory results = _shoppe.PerformQuery(requestedItem);
        var list = results.GetInventory();
        string displayResults = _shoppe.DisplayQuery(results);
        _output.WriteLine(displayResults);

        // Confirm purchase and quantity
        int count = list.Count();
        int itemNumber = -1;

        while (itemNumber != 0)
        {
            _output.Write($"\nPurchase an item? Enter item number 1-{count} or 0 to continue (default): ");
            string? input = _input.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                itemNumber = 0;
            }
            else if (int.TryParse(input, out int value))
            {
                itemNumber = value;
            }

            if (itemNumber > 0 && itemNumber <= count)
            {
                InventoryItem selectedItem = list[itemNumber - 1];
                while (selectedItem.StockCount == 0)
                {
                    _output.Write(
                        "\nItem is currently out of stock. Is there another you'd like to purchase? Enter item number: ");
                    itemNumber = int.Parse(_input.ReadLine());
                    selectedItem = list[itemNumber - 1];
                }

                _output.Write($"Quantity for \"{selectedItem.Name}\" (1-{selectedItem.StockCount}): ");
                string? qty = _input.ReadLine();
                if (!string.IsNullOrWhiteSpace(qty) && int.TryParse(qty, out int quantity) && quantity > 0 &&
                    quantity <= selectedItem.StockCount)
                {
                    // Add to order
                    if (_shoppe.AddToOrder(selectedItem, quantity))
                    {
                        _output.WriteLine("Item added to order.");
                    }
                    else
                    {
                        _output.WriteLine("We were unable to add the item to your order.");
                    }
                }
                else
                {
                    _output.WriteLine("Invalid input. Please try again.");
                }
            }
        }
    }

// Customer checkout.
    public void CheckOut()
    {
        string order = _shoppe.DisplayOrder();
        int method;
        IPaymentStrategy strategy;
        _output.WriteLine(order);

        // Request payment type
        List<IPaymentStrategy> strategies = new List<IPaymentStrategy>
        {
            new CreditCard(_input, _output),
            new ApplePay(_input, _output),
            new CryptoCurrency(_input, _output)
        };

        while (true)
        {
            _output.Write(selectMethod);
            string entry = _input.ReadLine();
            if (!string.IsNullOrWhiteSpace(entry) && int.TryParse(entry, out method) && method >= 1 &&
                method <= strategies.Count)
            {
                strategy = strategies[method - 1];
                break;
            }
            
            _output.WriteLine("Invalid method selection.");
        }

        // Accept payment
        string receipt = _shoppe.AcceptPayment(strategy);
        _output.WriteLine(receipt);
    }


// Open shoppe and take requests.
    private RequestedItem ShoppeOpen()
    {
        RequestedItem item = new RequestedItem();
        string input;
        _output.WriteLine("\n========================Welcome to Sweet Teas===============================");
        _output.WriteLine("\nComplete the prompts to search our selection of fine teas.\n");

        _output.Write("* Tea name contains (leave blank for all names): ");
        item.SearchName = _input.ReadLine();

        _output.Write("* Is available? (Y/N, default all): ");
        string? entry = _input.ReadLine();
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

        _output.Write("* Price minimum (default $0): ");
        input = _input.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (decimal.TryParse(input, out decimal price))
            {
                item.MinPrice = decimal.Parse(input);
            }
        }

        _output.Write("* Price maximum (default $1000): ");
        input = _input.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (decimal.TryParse(input, out decimal price))
            {
                item.MaxPrice = decimal.Parse(input);
            }
        }

        _output.Write("* Star rating minimum (1-5, default 1): ");
        input = _input.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (int.TryParse(input, out int starRating))
            {
                item.MinRating = starRating;
            }
        }

        _output.Write("* Star rating maximum (1-5, default 5): ");
        input = _input.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (int.TryParse(input, out int starRating))
                item.MaxRating = starRating;
        }

        _output.Write("* Minimum quantity (default 1): ");
        input = _input.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (int.TryParse(input, out int quantity))
            {
                item.Quantity = quantity;
            }
        }

        _output.Write("* Sort Priority (P for Price, R for Rating, default P): ");
        input = _input.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (char.ToUpper(input[0]) == 'R')
            {
                item.Sort = PrimarySort.Rating;
            }
        }

        _output.Write("* Sort by Price (A/D, default A): ");
        input = _input.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (char.ToUpper(input[0]) == 'D')
            {
                item.PriceDirection = SortDirection.Descending;
            }
        }

        _output.Write("* Sort by Star rating (A/D, default D): ");
        input = _input.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (char.ToUpper(input[0]) == 'A')
            {
                item.RatingDirection = SortDirection.Ascending;
            }
        }

        return item;
    }
}