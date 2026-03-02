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


    public TeaShoppeFacade()
    {
        _catalog = new TeaCatalog();
        currentRepo = new TeaInventory(_catalog.Items);
    }

    // Request an item from the shoppe.
    public IInventory Query(RequestedItem requestedItem)
    {
        IInventory teaRepo = currentRepo;
        teaRepo = new TeaByName(teaRepo, requestedItem);
        teaRepo = new TeaByAvailability(teaRepo, requestedItem);
        teaRepo = new TeaByPrice(teaRepo, requestedItem);
        teaRepo = new TeaByRating(teaRepo, requestedItem);
        teaRepo = new SortTeas(teaRepo, requestedItem);
        return teaRepo;
    }

    // Add item to order.
    public void AddToOrder(InventoryItem item, int  quantity)
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
    
    // Review order.
    public string DisplayOrder(Order order)
    {
        return _order.OrderDetails();
    }

    // Make Payment.
    public void AcceptPayment(IPaymentStrategy strategy)
    {
        _paymentProcessor = new PaymentProcessor(strategy);
        _paymentProcessor.Checkout(_order);
    }
    
    // Run shoppe.
    
    
    
    
}