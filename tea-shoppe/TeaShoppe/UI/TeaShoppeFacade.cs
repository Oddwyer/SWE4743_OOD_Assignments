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
    private TeaInventory _currentRepo;
    private InventoryQueryBuilder _queryBuilder = new();
    private InventoryQueryOutputWriter _writer;
    private TextWriter _output;
    private TextReader _input;

    public TeaShoppeFacade(TextReader input, TextWriter output)
    {
        _catalog = new TeaCatalog();
        _currentRepo = new TeaInventory(_catalog.Items);
        _input = input;
        _output = output;
    }

    // Perform query and display results.
    public void PerformQuery(RequestedItem requestedItem)
    {
        IInventory teaRepo = _currentRepo;
        var output = _queryBuilder.PerformQuery(requestedItem, teaRepo);
        string results = output.DisplayQuery(teaRepo);
        _writer.Writer.WriteLine(results);
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
            for (int i = 0; i < _order.NumberOfLineItems(); i++)
            {
                OrderItem item = _order.GetItem(i);
                _currentRepo.Remove(item.SkuId, item.Quantity);
            }
            
        }
    }
}