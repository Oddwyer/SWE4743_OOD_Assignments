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
    private TeaCatalog _catalog;


    public TeaShoppeFacade()
    {
        _catalog = new TeaCatalog();
    }

    public IInventory Query(RequestedItem requestedItem)
    {
        IInventory _teaRepo = new TeaInventory(_catalog.Items);
        _teaRepo = new TeaByName(_teaRepo, requestedItem);
        _teaRepo = new TeaByAvailability(_teaRepo, requestedItem);
        _teaRepo = new TeaByPrice(_teaRepo, requestedItem);
        _teaRepo = new TeaByRating(_teaRepo, requestedItem);
        _teaRepo = new SortTeas(_teaRepo, requestedItem);
        return _teaRepo;
    }
}