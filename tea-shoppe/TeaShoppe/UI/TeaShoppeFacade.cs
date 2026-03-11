using TeaShoppe.Orders;
using TeaShoppe.Inventory;
using TeaShoppe.Decorators;
using TeaShoppe.Payment;

namespace TeaShoppe.UI;

/// <summary>
/// TeaShoppe workflow class using Facade pattern to keep composition root minimal.
/// </summary>
public class TeaShoppeFacade
{
    private Order _order = new Order();
    private PaymentProcessor _paymentProcessor;
    private readonly TeaCatalog _catalog;
    private TeaInventory currentRepo;
    private TextReader _input;
    private TextWriter _output;

    public TeaShoppeFacade(TextReader input, TextWriter output)
    {
        _catalog = new TeaCatalog();
        currentRepo = new TeaInventory(_catalog.Items);
        _input = input;
        _output = output;
    }

    // Request an item from the shoppe.
    public IInventory PerformQuery(RequestedItem requestedItem)
    {
        IInventory teaRepo = currentRepo;
        teaRepo = new TeaByName(teaRepo, requestedItem);
        teaRepo = new TeaByAvailability(teaRepo, requestedItem);
        teaRepo = new TeaByPrice(teaRepo, requestedItem);
        teaRepo = new TeaByRating(teaRepo, requestedItem);
        teaRepo = new TeaByQuantity(teaRepo, requestedItem);
        teaRepo = new SortTeas(teaRepo, requestedItem);
        return teaRepo;
    }

    // Display search results
    public string DisplayQuery(IInventory query)
    {
        string qty = "";
        var queryResults = query.GetInventory();
        string results = $"\n{queryResults.Count} items match your query:\n";
        int itemNumber = 1;
        foreach (var item in queryResults)
        {
            if (!item.InStock)
            {
                qty = "(OUT OF STOCK)";
            }
            else
            {
                qty = item.StockCount.ToString();
            }

            results += $"{itemNumber}. {item.Name,-15}\t${item.RetailPrice}\tQty: {qty,15}  {item.RatingValue} stars\n";
            itemNumber++;
        }

        return results;
    }

    // Add item(s) to order.
    public bool AddToOrder(InventoryItem item, int quantity)
    {
        OrderItem orderItem = new OrderItem(item);

        if (_order.AddItem(orderItem, quantity))
        {
            return true;
        }
        return false;
    }

    // Remove item(s) from order.
    public bool RemoveFromOrder(InventoryItem item, int quantity)
    {
        OrderItem orderItem = new OrderItem(item);
        if (_order.RemoveItem(orderItem, quantity))
        {
            currentRepo.Add(item, quantity);
            return true;
        }

        return false;
    }

    // Display order.
    public string DisplayOrder()
    {
        return _order.OrderDetails();
    }

    // Accept payment.
    public void AcceptPayment(IPaymentStrategy strategy)
    {
        _paymentProcessor = new PaymentProcessor(strategy, _input, _output);
        if (_paymentProcessor.ProcessPayment(_order))
        {
            for (int i = 0; i < _order.TotalItemCount(); i++)
            {
                OrderItem item = _order.GetItem(i);
                currentRepo.Remove(item.SkuId, item.Quantity);
            }
            
        }
    }
}