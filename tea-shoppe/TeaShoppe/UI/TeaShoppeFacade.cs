using TeaShoppe.Orders;
using TeaShoppe.Inventory;
using TeaShoppe.Decorators;
using TeaShoppe.Payment;

namespace TeaShoppe.UI;

/// <summary>
/// TeaShoppe workflow class. 
/// </summary>
public class TeaShoppeFacade
{
    private Order _order;
    private PaymentProcessor _paymentProcessor;
    private readonly TeaCatalog _catalog;
    private TeaInventory currentRepo;
    IPaymentStrategy strategy;
    
    public TeaShoppeFacade()
    {
        _catalog = new TeaCatalog();
        currentRepo = new TeaInventory(_catalog.Items);
    }
    
    // Request an item from the shoppe.
    public IInventory PerformQuery(RequestedItem requestedItem)
    {
        IInventory teaRepo = currentRepo;
        teaRepo = new TeaByName(teaRepo, requestedItem);
        teaRepo = new TeaByAvailability(teaRepo, requestedItem);
        teaRepo = new TeaByPrice(teaRepo, requestedItem);
        teaRepo = new TeaByRating(teaRepo, requestedItem);
        teaRepo = new SortTeas(teaRepo, requestedItem);
        return teaRepo;
    }

    // Display search results
    public string DisplayQuery(IInventory query)
    {
        string qty = "";
        var queryResults = query.GetInventory();
        string results = $"{queryResults.Count} items match your query:";
        int itemNumber = 1;
        foreach (var item in queryResults)
        {
            if (!item.InStock)
            {
                qty = "(OUT OF STOCK)";
            }
            else
            {
                qty = item.Quantity.ToString();
            }

            results += $"{itemNumber}. {item.Name}\t${item.RetailPrice}  Qty:{qty}\t{item.RatingValue} stars\n";
            itemNumber++;
        }

        return results;
    }

    // Add item to order.
    public void AddToOrder(InventoryItem item, int quantity)
    {
        OrderItem orderItem = new OrderItem(item, quantity);
        _order.AddItem(orderItem);
        currentRepo.Remove(item);
    }

    // Remove item from order.
    public void RemoveFromOrder(InventoryItem item, int quantity)
    {
        OrderItem orderItem = new OrderItem(item, quantity);
        _order.RemoveItem(orderItem);
        currentRepo.Add(item);
    }

    // Display order.
    public string DisplayOrder(Order order)
    {
        return _order.OrderDetails();
    }
    
    // Accept payment.
    public void AcceptPayment(int paymentMethod)
    {
        switch (paymentMethod)
        {
            case 1:
                TextReader input = new StringReader("");
                TextWriter output = new StringWriter();
                strategy = new CreditCard(input, output);
                break;
            case 2:
                strategy = new ApplePay();
                break;
            case 3:
                strategy = new CryptoCurrency();
                break;
            default:
                Console.Write("Please enter a valid choice: ");
                break;
        }

        _paymentProcessor = new PaymentProcessor(strategy);
        _paymentProcessor.Checkout(_order);
    }
}